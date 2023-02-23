from PIL import Image

# Открываем изображение
image = Image.open('text_image.png')

# Получаем пиксели изображения
pixels = image.load()

# Получаем последовательность нулей и единиц из пикселей
binary_text = ''
for x in range(image.width):
    for y in range(image.height):
        color = pixels[x, y]
        if color == (255, 255, 255):
            binary_text += '0'
        else:
            binary_text += '1'

# Разбиваем последовательность нулей и единиц на байты и декодируем их в текст
text = ''
for i in range(0, len(binary_text), 8):
    byte = binary_text[i:i+8]
    char = chr(int(byte, 2))
    text += char

# Выводим декодированный текст
print(u/text)
