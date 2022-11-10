# TekNET

#To use, WIP


* Send VCALL737
* Wait RCALL858
* Send NT## (must be sent as two digit)
* Wait NTACK
* Send TKtech1,tech2,tech3 (Tech list must be Comma seped)
* Wait TKACK
* Send CAP## (must be sent as two digit)
* Wait CAPACK
* Send TOMR
* Wait RFT
* Send TOMxxxxxxxxxxxxxxx(MSG is variable len)
* Wait TOMACK
* Send CHKSUM
* System will send back CHKSUMAK if good
* or CHKSUMNAK if bad
* If bad, send TOM and CHKSUM again
* Once Tone out is complete RFNM will be sent and system is waiting for VCALL737
*
*
*System will send NAK in responce to any command, If NAK is RXed, Resend command.
*Checksum is MD5
