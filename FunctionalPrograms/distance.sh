#! /bin/bash
read -p 'enter the value of x: ' x
read -p 'enter the value of y: ' y
awk -v x=$x -v y=$y 'BEGIN { printf ("%.1f" , (sqrt(x*x+y*y)))}'
