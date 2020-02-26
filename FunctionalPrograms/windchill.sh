#! /bin/bash
read -p 'enter the temp: ' t
read -p 'enter the wind speed: ' v
if [ $v -gt 120 -o $v -lt 3 ]
then
echo "invalid wind speed...................."
else
awk -v t=$t -v v=$v 'BEGIN {printf ("%0.3f" , (35.74+(0.6125*t)+((0.4275*t)-35.75)*(v^0.16)))}'
fi
