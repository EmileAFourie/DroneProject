import cv2
import torch
import numpy as np
from twilio.rest import Client

# Your Twilio Account SID and Auth Token
account_sid = 'AC23b601fb4dbe7e1c1e5ead51dae7dba7'
auth_token = '8ea6e96f3379c860bdb67875c9d7616e'

# Your Twilio phone number
twilio_phone_number = '+13344893749'

# Recipient phone number where you want to send the SMS
recipient_phone_number = '+27763237618'

def main():
    points = []

    def send_sms(message_body):
        client = Client(account_sid, auth_token)

        message = client.messages.create(
            body=message_body,
            from_=twilio_phone_number,
            to=recipient_phone_number
        )

        print(f"SMS sent with SID: {message.sid}")

    def POINTS(event, x, y, flags, param):
        if event == cv2.EVENT_MOUSEMOVE:
            colorsBGR = [x, y]
            print(colorsBGR)

    cv2.namedWindow('FRAME', cv2.WINDOW_NORMAL)  # Set window properties
    cv2.setMouseCallback('FRAME', POINTS)

    # Load your best.pt model

    model = torch.hub.load('ultralytics/yolov5', 'custom', path='best.pt')

    cap = cv2.VideoCapture('Tigers.mp4')  # Change the video file name to the one with tigers

    tiger_list = []  # List to store tracked tigers
    sms_message = ""  # Initialize SMS message as an empty string

    frame_counter = 0
    process_every_n_frames = 3  # Process every second frame
    distance_threshold = 100  # Adjust this threshold as needed

    while True:
        ret, frame = cap.read()
        if not ret:
            break

        frame_counter += 1
        if frame_counter % process_every_n_frames != 0:
            continue

        frame = cv2.resize(frame, (800, 450))  # Resize frame for faster processing

        results = model(frame)

        for index, row in results.pandas().xyxy[0].iterrows():
            x1 = int(row['xmin'])
            y1 = int(row['ymin'])
            x2 = int(row['xmax'])
            y2 = int(row['ymax'])
            d = row['name']
            cx = int((x1 + x2) / 2)
            cy = int((y1 + y2) / 2)
            if 'tiger' in d:  # Adjust to 'tiger'
                detected = False
                for tiger in tiger_list:
                    if is_near((cx, cy), tiger, distance_threshold):
                        detected = True
                        break
                if not detected:
                    cv2.rectangle(frame, (x1, y1), (x2, y2), (0, 0, 255), 3)
                    cv2.putText(frame, str(d), (x1, y1), cv2.FONT_HERSHEY_PLAIN, 2, (255, 0, 0), 2)
                    tiger_list.append((cx, cy))

        cv2.putText(frame, f"Total Tigers: {len(tiger_list)}", (50, 49), cv2.FONT_HERSHEY_PLAIN, 2, (255, 0, 0), 2)

        cv2.imshow("FRAME", frame)

        key = cv2.waitKey(1)

    cap.release()
    cv2.destroyAllWindows()

    # Send a single SMS with the total number of tigers detected
    sms_message = f"Total tigers detected: {len(tiger_list)}"
    send_sms(sms_message)

    # Save the counts to a text file
    with open("tiger_counts.txt", "w") as file:
        file.write(str(len(tiger_list)) + "\n")

    print("Count of unique tigers saved to tiger_counts.txt and SMS sent.")

def is_near(point, tiger, threshold):
    tiger_center = tiger
    distance = np.linalg.norm(np.array(point) - np.array(tiger_center))
    return distance < threshold

if __name__ == "__main__":
    main()
