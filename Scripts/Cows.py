import cv2
import torch
import numpy as np
from twilio.rest import Client

# Your Twilio Account SID and Auth Token
account_sid = 'AC467d3314af4d8c76c9411537b69106ef'
auth_token = '32e439d70bb911790a061b997fbdb7f8'

# Your Twilio phone number
twilio_phone_number = '+12052363623'

# Recipient phone number where you want to send the SMS
recipient_phone_number = '+27661862212'

# Threshold for high temperature (adjust as needed)
high_temp_threshold = 38.0  # Example threshold, change it accordingly


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

    def points(event, x, y, flags, param):
        if event == cv2.EVENT_MOUSEMOVE:
            colorsBGR = [x, y]
            print(colorsBGR)

    cv2.namedWindow('FRAME')
    cv2.setMouseCallback('FRAME', points)

    model = torch.hub.load('ultralytics/yolov5', 'yolov5s', pretrained=True)

    cap = cv2.VideoCapture('Cows.mp4')

    cow_list = []  # List to store tracked cows
    cow_temperatures = []  # List to store temperatures of cows
    sms_message = ""  # Initialize SMS message as an empty string

    frame_counter = 0
    process_every_n_frames = 2  # Process every second frame
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
            if 'cow' in d:
                if not any(is_near((cx, cy), cow, distance_threshold) for cow in cow_list):
                    cv2.rectangle(frame, (x1, y1), (x2, y2), (0, 0, 255), 3)
                    cv2.putText(frame, str(d), (x1, y1), cv2.FONT_HERSHEY_PLAIN, 2, (255, 0, 0), 2)
                    cow_list.append((cx, cy))

                    # Simulate temperature measurement (replace with actual measurement)
                    temperature = np.random.uniform(36.0, 40.0)  # Example temperature, replace with actual reading
                    temperature = round(temperature, 2)  # Round to 2 decimal places
                    cow_temperatures.append(temperature)

        cv2.putText(frame, f"Total Cows: {len(cow_list)}", (50, 49), cv2.FONT_HERSHEY_PLAIN, 2, (255, 0, 0), 2)

        cv2.imshow("FRAME", frame)

        key = cv2.waitKey(1)

    cap.release()
    cv2.destroyAllWindows()

    # Calculate average temperature
    if cow_temperatures:
        avg_temperature = sum(cow_temperatures) / len(cow_temperatures)
        avg_temperature = round(avg_temperature, 2)  # Round to 2 decimal places
        sms_message += f"Total cows: {len(cow_list)}, Average Temperature: {avg_temperature}°C\n"

    # Check for cows over the temperature threshold and include in the SMS
    high_temp_cows = [f"Cow {i + 1}: {temp}°C" for i, temp in enumerate(cow_temperatures) if temp > high_temp_threshold]
    if high_temp_cows:
        sms_message += "\nCows with high temperature:\n" + "\n".join(high_temp_cows)

    # Send a single SMS with all the information
    if sms_message:
        send_sms(sms_message)

    # Save the counts to a text file
    with open("cow_counts.txt", "w") as file:
        file.write(str(len(cow_list)) + "\n")

    print("Count of unique cows saved to cow_counts.txt and SMS sent.")


def is_near(point, cow, threshold):
    cow_center = cow
    distance = np.linalg.norm(np.array(point) - np.array(cow_center))
    return distance < threshold

if __name__ == "__main__":
    main()
