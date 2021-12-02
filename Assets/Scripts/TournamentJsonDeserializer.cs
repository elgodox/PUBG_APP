using Newtonsoft.Json;

public class TournamentJsonDeserializer
{
    public RequestData Deserialize(string json)
    {
        return JsonConvert.DeserializeObject<RequestData>(json);
    }
}