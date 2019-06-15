## Утсановка
https://git-scm.com/download/win
https://code.visualstudio.com/Download

## Глобальная настройка
git config --global user.name "Ilya Kataev"
git config --global user.email "kataev.i@gmail.com"

## Генерация ключа
Заходим в ~/Documents
Если нет 
ssh-keygen -t rsa -b 4096 -C "kataev.i@gmail.com"
Filename: id_rsa

## Проверка авторизации
Проверка
ssh -vT git@github.com

