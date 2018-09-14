public class Codec {
    Dictionary<string, string> dictLtoS;
    Dictionary<string, string> dictStoL;
    
    private string alphabets = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    // Encodes a URL to a shortened URL
    public Codec(){
		dictLtoS =  new Dictionary<string, string>();
		dictStoL = new Dictionary<string, string>();
	}
	public string encode(string longUrl) {
        if(dictLtoS.ContainsKey(longUrl)) {
            var code = string.Empty;
            dictLtoS.TryGetValue(longUrl, out code);
            return string.Format("http://tinyurl.com/{0}", code);
        } else {
            var code = createCode();
            dictLtoS.Add(longUrl, string.Format("http://tinyurl.com/{0}", code));
            dictStoL.Add(string.Format("http://tinyurl.com/{0}", code), longUrl);
            return string.Format("http://tinyurl.com/{0}", code);
        }
    }
    
    private string createCode() {
        Random rnd = new Random();
        var code = string.Empty;
        for(int i = 0; i < 6; i++) {
            int randNum = rnd.Next(1, alphabets.Length);
            code = code + alphabets[randNum]; 
        }
        return code;
    }
    
    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) {
        var originalUrl = string.Empty;
        dictStoL.TryGetValue(shortUrl, out originalUrl);
        return originalUrl;
    }
}
