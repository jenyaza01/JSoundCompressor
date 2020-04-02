namespace JSoundCompressor
{
	public static class Settings
	{
		public static bool secondInputEnabled = false;
		public static bool secondOutputEnabled = false;
		public static bool changed = false;
		public static string freq = "48000";
		public static string inputMS = "20";
		public static string outputMS = "60";
        public static int freq_int => int.Parse(freq);
        public static int inputMS_int => int.Parse(inputMS);
        public static int outputMS_int => int.Parse(outputMS);
        public static string[] args { get; set; }
    }
}
