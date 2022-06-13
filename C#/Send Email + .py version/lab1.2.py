#!/usr/bin/env python3
import smtplib
from datetime import datetime
from email.message import EmailMessage
to = input("Input to-addr: ")
subject = input("Input subject of mail: ")
date = str(datetime.now())
if not (to and to.isspace()) and not (subject and subject.isspace()):
        server = smtplib.SMTP("smtp.gmail.com", 587)
        server.starttls()
        server.login("barpenchuk@gmail.com", "password")
        msg = EmailMessage()
        msg['Subject'] = subject
        msg['From'] = "barpenchuk@gmail.com"
        msg['To'] = to
        msg.set_content(date + " Karpenchuk Bohdan")
        server.send_message(msg)
else:
        print("SYNTAX: <to addr> <subject>")
