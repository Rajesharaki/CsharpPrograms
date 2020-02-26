//user input program
read -p 'enter your name : ' name
if [ ${#name} -ge 3 ]
then
echo "Hello $name , How are you...!"
else 
echo enter a valid name...!
fi
