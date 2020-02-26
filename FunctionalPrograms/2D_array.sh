#! /bin/bash
read -p 'enter the number of row; ' row
read -p 'enter the number of col; ' col
declare -A array
readArray(){
for (( i=0; i<$row ; i++ ))
do
   for (( j=0; j<$col ; j++ ))
   do
   read -p 'enter the values: ' value
   array[$i,$j]=$value
   done
done
}
displayArray(){
for (( i=0; i<$row ; i++ ))
do
   for (( j=0; j<$col ; j++ ))
   do
   echo -e "${array[$i,$j]} \c"
   done
echo
done
}
readArray
displayArray
