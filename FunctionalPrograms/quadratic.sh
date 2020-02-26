#! /bin/bash
read -p 'enter value for a: ' a
read -p 'enter value for b: ' b
read -p 'enter value for c: ' c
root1=0
root2=0
delta=$(awk -v x=$a -v y=$b -v z=$c 'BEGIN { print (y*y-4*x*z ) } ')
echo "$delta"
if [ $(awk -v var=$delta 'BEGIN { print ( delta > 0 ) } ') ]
then
root1=$( awk -v det=$delta -v x=$a -v y=$b 'BEGIN {print ((-y + (det**0.5))/(2*x)) }')
root2=$( awk -v det=$delta -v x=$a -v y=$b 'BEGIN {print ((-y - (det**0.5))/(2*x)) }'  )
echo root1 and root2 are $root1 , $root2
elif (( $delta == 0 ))
then
root1=$(awk -v x=$a -v y=$b 'BEGIN {print(-y/(2*x)) } ')
echo $root1
else
actual=$(awk -v x=$a -v y=$b 'BEGIN { print (-y/(2*x) ) } '  )
imaginary=$(awk -v det=$delta -v x=$a 'BEGIN{print ((-det/(2*x))**0.5)}')
echo "( $actual ,  $imaginary )"
fi
