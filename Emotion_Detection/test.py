#Import required modules
import cv2, glob, random, math, numpy as np, dlib, itertools,time
from sklearn.externals import joblib

#Set up some required objects
video_capture = cv2.VideoCapture(0) #Webcam object
detector = dlib.get_frontal_face_detector() #Face detector
predictor = dlib.shape_predictor("shape_predictor_68_face_landmarks.dat") #Landmark identifier
clf = joblib.load('my_model.pkl')
emotions = ["anger", "contempt", "disgust", "fear", "happy", "neutral", "sadness", "surprise"] #Emotion list
previous_emotion = "neutral"

def get_landmarks(frame):
    detections = detector(image, 1)
    for k,d in enumerate(detections): 
        shape = predictor(image, d) 
        xlist = []
        ylist = []
        for i in range(1,68): #Store X and Y coordinates in two lists
            xlist.append(float(shape.part(i).x))
            ylist.append(float(shape.part(i).y))
            
        xmean = np.mean(xlist) #Get the mean of both axes to determine centre of gravity
        ymean = np.mean(ylist)
        xcentral = [(x-xmean) for x in xlist] #get distance between each point and the central point in both axes
        ycentral = [(y-ymean) for y in ylist]

        if xlist[26] == xlist[29]: #If x-coordinates of the set are the same, the angle is 0, catch to prevent 'divide by 0' error in function
            anglenose = 0
        else:
            anglenose = int(math.atan((ylist[26]-ylist[29])/(xlist[26]-xlist[29]))*180/math.pi)

        if anglenose < 0:
            anglenose += 90
        else:
            anglenose -= 90

        landmarks_vectorised = []
        for x, y, w, z in zip(xcentral, ycentral, xlist, ylist):
            landmarks_vectorised.append(x)
            landmarks_vectorised.append(y)
            meannp = np.asarray((ymean,xmean))
            coornp = np.asarray((z,w))
            dist = np.linalg.norm(coornp-meannp)
            anglerelative = (math.atan((z-ymean)/(w-xmean))*180/math.pi) - anglenose
            landmarks_vectorised.append(dist)
            landmarks_vectorised.append(anglerelative)

    if len(detections) < 1: 
        landmarks_vectorised = "error"
    return landmarks_vectorised



def get_emotion_proba(landmarks_vectorised):
    global previous_emotion
    if(landmarks_vectorised != "error"):
    	landmarks_vectorised = np.array(landmarks_vectorised).reshape(1,-1)
	list_proba = clf.predict_proba(landmarks_vectorised)[0]

	return list_proba

    else:
        return [0,0,0,0,0,0,0,0]


while True:
    loop_count = 0
    emotions_proba = [0,0,0,0,0,0,0,0]

    while(loop_count < 3):
	ret, frame = video_capture.read()

	gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
	clahe = cv2.createCLAHE(clipLimit=2.0, tileGridSize=(8,8))
	image = clahe.apply(gray)

        #Resize the image for optimization
        n = 2 #Bigger n => Smaller image => Better FPS 
        oldHeight = frame.shape[0]
        oldWidth = frame.shape[1]
        newHeight = int(oldHeight/n)
        newWidth = int(oldWidth/n)
        newDim = (newWidth, newHeight)
        frame = cv2.resize(frame, newDim, interpolation = cv2.INTER_AREA)

	landmarks_vectorised = get_landmarks(frame)
    	for i in range(0,8):
 	    emotions_proba[i] = emotions_proba[i] + get_emotion_proba(landmarks_vectorised)[i]

	loop_count = loop_count + 1
    
    max_proba = max(emotions_proba)
    emotion_num = 0
    while(emotions_proba[emotion_num] != max_proba):
        emotion_num=emotion_num+1

    current_emotion = emotions[emotion_num]
    if(current_emotion != previous_emotion):
        print(current_emotion + "\n")
	previous_emotion = current_emotion
	
    if cv2.waitKey(1) & 0xFF == ord('q'): #Exit program when the user presses 'q'
        break
    
