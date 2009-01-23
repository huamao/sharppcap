using System;
using System.Runtime.InteropServices;

namespace SharpPcap.PcapUnmanagedStructures
{
	#region Unmanaged Structs Implementation

	/// <summary>
	/// Item in a list of interfaces.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
		public struct pcap_if 
	{
		public IntPtr /* pcap_if* */	Next;			
		public string					Name;			/* name to hand to "pcap_open_live()" */				
		public string					Description;	/* textual description of interface, or NULL */
		public IntPtr /*pcap_addr * */	Addresses;
		public uint						Flags;			/* PCAP_IF_ interface flags */
	};

	/// <summary>
	/// Representation of an interface address.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
		public struct pcap_addr 
	{
		public IntPtr /* pcap_addr* */	Next;
		public IntPtr /* sockaddr * */	Addr;		/* address */
		public IntPtr /* sockaddr * */  Netmask;	/* netmask for that address */
		public IntPtr /* sockaddr * */	Broadaddr;	/* broadcast address for that address */
		public IntPtr /* sockaddr * */	Dstaddr;	/* P2P destination address for that address */
	};

	/// <summary>
	/// Structure used by kernel to store most addresses.
	/// 'struct sockaddr'
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
		internal struct sockaddr 
	{
		public UInt16		sa_family;       /* address family */
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=14)]
		public byte[]		sa_data;         /* up to 14 bytes of direct address */
	};

    /// <summary>
    /// Structure that holds ipv6 addresses
    /// NOTE: we cast the 'struct sockaddr*' to this structure based on the sa_family type
    /// 'struct sockaddr_in6'
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
        internal struct sockaddr_in6
    {
        public UInt16       sin6_family;    /* address family */
        public UInt16       sin6_port;      /* Transport layer port # */
        public UInt32       sin6_flowinfo;  /* IPv6 flow information */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=16)]
        public byte[]       sin6_addr;      /* IPv6 address */
        public UInt32       sin6_scope_id;  /* scope id (new in RFC2553) */
    };
	/// <summary>
	/// Each packet in the dump file is prepended with this generic header.
	/// This gets around the problem of different headers for different
	/// packet interfaces.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
		public struct pcap_pkthdr 
	{											//timestamp
		public int		tv_sec;				///< seconds
		public int		tv_usec;			///< microseconds
		public int		caplen;			/* length of portion present */
		public int		len;			/* length this packet (off wire) */
	};

	/// <summary>
    /// Packet data bytes
    /// NOTE: This struct doesn't exist in header files, it is a construct to map to an
    ///        unmanaged byte array
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
		internal struct PCAP_PKTDATA
	{	
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=SharpPcap.Pcap.MAX_PACKET_SIZE)]						
		public byte[]		bytes;
	};

	/// <summary>
	/// A BPF pseudo-assembly program for packet filtering
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
		internal struct bpf_program 
	{
		public uint bf_len;                
		public IntPtr /* bpf_insn **/ bf_insns;  
	};

	/// <summary>
	/// A queue of raw packets that will be sent to the network with pcap_sendqueue_transmit()
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
		internal struct pcap_send_queue 
	{
		public uint maxlen;   
        public uint len;   
		public IntPtr /* char **/ ptrBuff;  
	};

	#endregion Unmanaged Structs Implementation
}
