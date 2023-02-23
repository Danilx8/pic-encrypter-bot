from PIL import Image
import random

# Текст, который нужно закодировать
text = "А я и по-русски могу!"

# Получаем последовательность нулей и единиц для текста
binary_text = ''.join(format(ord(char), 'b').zfill(8) for char in text)

# Размер изображения
image_width = len(binary_text) // 3 + 1
image_height = 3

# Создаем изображение
image = Image.new('RGB', (image_width, image_height), color='white')

# Получаем пиксели изображения
pixels = image.load()

# Заполняем пиксели на основе последовательности нулей и единиц
i = 0
for x in range(image_width):
    for y in range(image_height):
        if i < len(binary_text):
            bit = int(binary_text[i])
            if bit == 1:
                color = (random.randint(0, 255), random.randint(0, 255), random.randint(0, 255))
            else:
                color = (255, 255, 255)
            pixels[x, y] = color
            i += 1

# Сохраняем изображение в файл
image.save('text_image.png')
