#! /bin/bash
echo "Stopwatch started hit ctrl+C to stop the Stopwatch....!"
start_time="$(date +%s)"
while (( 1 ))
do
let current_time="$(date +%s)"
let seconds=$(($current_time-$start_time))
#this to is to print the
echo -ne "\r"
printf "%02d:%02d:%02d:%02d" "$((seconds/86400))" "$((seconds/3600%24))" "$((seconds/60%60))" "$((seconds%60))"
sleep 1
done
