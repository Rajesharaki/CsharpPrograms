# generating a coupon randomly
#setting the arrays for coupon number
small=({a..z})
big=({A..Z})
read -p 'how many distinct coupon you want to be generated....: ' n
while [ $n -gt 0 ]
do
a=$(shuf -i 0-25 -n 1)
b=$(shuf -i 0-25 -n 1)
random1=$( shuf -i 0-25 -n 1 )
random2=$( shuf -i 0-25 -n 1 )
#coupon number generated with 6 random number generations
echo -ne "\r the generated coupon number is:"
echo $b$a${small[$random1]}${big[$random2]}${small[$a]}$b
let n--
done
