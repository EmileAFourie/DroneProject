import cv2
from twilio.rest import Client

# Your Twilio Account SID and Auth Token
account_sid = 'AC23b601fb4dbe7e1c1e5ead51dae7dba7'
auth_token = '8ea6e96f3379c860bdb67875c9d7616e'

# Your Twilio phone number
twilio_phone_number = '+13344893749'

# Recipient phone number where you want to send the SMS
recipient_phone_number = '+27763237618'

# Function to send an SMS using Twilio
def send_sms(message_body):
    client = Client(account_sid, auth_token)

    message = client.messages.create(
        body=message_body,
        from_=twilio_phone_number,
        to=recipient_phone_number
    )

    print(f"SMS sent with SID: {message.sid}")

# Function to simulate temperature estimation from the color channels
def simulate_temperature(frame):
    # Split the frame into B, G, and R channels
    b, g, r = cv2.split(frame)

    # Calculate a simulated temperature value (adjust as needed)
    mean_color = (r.mean() + g.mean() + b.mean()) / 3

    # Adjust the simulated temperature to be in the desired range (e.g., 35-38°C)
    adjusted_temperature = 35 + (mean_color / 255) * 3  # Assumes color values in the range [0, 255]

    return adjusted_temperature

def main():
    cap = cv2.VideoCapture('ThermalCow.mp4')  # Replace with the path to your thermal video

    frame_counter = 0
    process_every_n_frames = 2  # Process every second frame
    temperature = 0.0  # Initialize temperature with a default value

    while True:
        ret, frame = cap.read()
        if not ret:
            break

        frame_counter += 1
        if frame_counter % process_every_n_frames != 0:
            continue

        frame = cv2.resize(frame, (800, 450))  # Resize frame for faster processing

        # Simulate temperature estimation from the frame
        temperature = simulate_temperature(frame)

        # Convert temperature to a string without extra question marks
        temperature_str = f"Temperature: {temperature:.2f}'C"

        # Display the temperature as text on the frame with blue color
        cv2.putText(frame, temperature_str, (50, 50), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 2)

        cv2.imshow("FRAME", frame)

        key = cv2.waitKey(100)  # Add a delay of 100 milliseconds (adjust as needed)

        if key == 27:  # Exit when the 'Esc' key is pressed
            break

    cap.release()
    cv2.destroyAllWindows()

    # Send a single SMS with the simulated temperature
    sms_message = f"Temperature of animal: {temperature:.2f}°C"
    send_sms(sms_message)

    # Save the temperature to a text file
    with open("temperature.txt", "w") as file:
        file.write(f"{temperature:.2f}\n")

    print("Temperature saved to temperature.txt and SMS sent.")

if __name__ == "__main__":
    main()
