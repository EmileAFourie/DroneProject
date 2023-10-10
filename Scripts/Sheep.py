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

    cv2.namedWindow('FRAME')  # Create a named window without specific properties
    cv2.setMouseCallback('FRAME', POINTS)

    model = torch.hub.load('ultralytics/yolov5', 'yolov5s', pretrained=True)

    cap = cv2.VideoCapture('Sheep3.mp4')  # Change the video file name to the one with sheep

    sheep_list = []  # List to store tracked sheep
    frame_counter = 1
    process_every_n_frames = 2  # Process every second frame
    distance_threshold = 70  # Adjust this threshold as needed

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
            if 'sheep' in d.lower():  # Check for sheep
                if not any(is_near((cx, cy), sheep, distance_threshold) for sheep in sheep_list):
                    cv2.rectangle(frame, (x1, y1), (x2, y2), (0, 0, 255), 3)
                    cv2.putText(frame, str(d), (x1, y1), cv2.FONT_HERSHEY_PLAIN, 2, (255, 0, 0), 2)
                    sheep_list.append((cx, cy))

        cv2.putText(frame, f"Total Sheep: {len(sheep_list)}", (50, 49), cv2.FONT_HERSHEY_PLAIN, 2, (255, 0, 0), 2)

        cv2.imshow("FRAME", frame)

        key = cv2.waitKey(1)

    cap.release()
    cv2.destroyAllWindows()

    # Save the sheep count to a text file
    sheep_count = len(sheep_list)
    with open("sheep_counts.txt", "w") as file:
        file.write(f"{sheep_count}\n")

    # Send a single SMS with the total number of sheep detected
    sms_message = f"Total sheep detected: {sheep_count}"
    send_sms(sms_message)

def is_near(point, sheep, threshold):
    sheep_center = sheep
    distance = np.linalg.norm(np.array(point) - np.array(sheep_center))
    return distance < threshold

if __name__ == "__main__":
    main()
