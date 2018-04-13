 #!/bin/sh
 t=`awk {'print $4'} $1`
 # debug
 # echo $t
  for ops in `echo $t | xxd -p`; 
	do
	ops1=`echo $ops | xxd -r -p`
	ops2=`echo $ops | xxd -r -p | xxd -r -p`
	echo $ops1 "==>" $ops2
	done
   echo
   echo "[;)] your Injected Bytes via Mac Addresses: "
   echo `echo $t`
   echo
   echo "[;o] your Data : "
   echo
   echo $t | xxd -r -p
