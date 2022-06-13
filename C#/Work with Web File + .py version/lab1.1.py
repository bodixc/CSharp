#!/usr/bin/env python3
import requests
get_file = requests.get("https://mail.univ.net.ua/readme.txt")
text = get_file.text
read_me = open ("ReadMe.txt", "w")
read_me.write(text)
read_me.close()
read_me = open ("ReadMe.txt", "r")
file_text = read_me.read()
read_me.close()
file_words = file_text.split(' ')
find_word = input("Input a word to find it: ")
change_word = "WORD FOUND!!!"
for i in range(len(file_words)):
        if file_words[i] == find_word:
                file_words[i] = change_word
read_text_light = ' '.join(file_words)
read_me_light = open ("ReadMe-Light.txt", "w")
read_me_light.write(read_text_light)
read_me_light.close()
