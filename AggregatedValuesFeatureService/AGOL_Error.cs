using System.Runtime.Serialization;


//"{\"error\":{\"code\":400,\"message\":\"Unable to generate token.\",\"details\":[\"Invalid username or password.\"]}}"

namespace SQLtoFeatureService
{
  [DataContract]
  class AGOL_Error
  {
    [DataMember]
    public error error { get; set; }
  }

  [DataContract]
  class error
  {
    [DataMember]
    public int code { get; set; }

    [DataMember]
    public string message { get; set; }

    [DataMember]
    public string[] details { get; set; }
  }
}
