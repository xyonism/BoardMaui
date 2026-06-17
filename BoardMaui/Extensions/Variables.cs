using Google.Apis.Auth.OAuth2;

namespace BoardMaui.Extensions;

public static class Variables
{
	public static GoogleCredential GoogleCredential => new ServiceAccountCredential(
			   new ServiceAccountCredential.Initializer(JsonCredentialParameters?.ClientEmail, JsonCredentialParameters?.TokenUri)
			   {
				   UniverseDomain = JsonCredentialParameters?.UniverseDomain,
				   ProjectId = JsonCredentialParameters?.ProjectId,
				   Scopes = [],
			   }.FromPrivateKey(JsonCredentialParameters?.PrivateKey)).ToGoogleCredential();
	public static JsonCredentialParameters JsonCredentialParameters
		=> new()
		{
			Type = "service_account",
			ProjectId = "synagogail",
			PrivateKeyId = "5489392576ef28170892358238cdbbbb0aaace24",
			PrivateKey = "-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDPySC3MOzR/pli\nRjSHV7PD9BkGm98sh1aon5JhmtvroaSbUoI2D+XriQ6+sxKCDenJzXAIkM1gELuJ\nYExcmCiGPtYuYARbiaPoINx0A+qx25VZfJCKiJZot1EaQLq9b2GRE4GCgWn5akYc\ndpPwXhUSt+WYxedGIxbIpG16aY7+09EF3xvwegGYtULRR3EVrIf6eIslX6kcRXZI\n2IVCgjkYLiumentMll5fdeEuI46tIHCp6YdVu4iOjb3UhufVkFe7m8BXIR021eYA\n9F5Wa+Xi646rG2V04MjBl07a5fIfuSjU+3TKOjr2df/UW6fZep4MMLlZayX73bWi\nWsKVWkFlAgMBAAECggEAC9wdA+0aTKTNjcXCux7kYdY4P3T8zgaDib23QImdl9ty\nu8gqf890fiHP4k6c9dNkJA1CdxqyE5Og61HAdLXdSkb34/m9sJkwmSVBsAAxOymf\nYquGIddzTlLNoZlO5Kp2KoOvLAsa82N/e6HBBpfizV4LECdA8MiRRQPYQ9kWkluG\nUmIRGSYpKYpPTaiDmjKN+aWEWD+EZxDLGAXoKvvCLYwDN1KxKJnOiBAuOUXd9TM/\n92RPMAzCKFspqZ7JvPAsZuFtc8ylPHxNILtrYsMH73wecCn7WbCjSMMG+6I1Pzlr\nToyf8Q3BmA0+L3ex0luZJhpLC18eqtjYnsuruGvswQKBgQD1WS1u1j2w5UkQm//P\n4LfTcRJBxAF8q4+lNAae56H4XFq9ziqOPqh2avludOp7k1/AM6UoQqIEPSSPNnsp\n/W9GGJGBn2m7RkqJzegclV0J1J4U3iXwDmnLUCtp0ITvOJpSf/zcnQmbncPdgeMv\nVcvESSvxL2NhjnhaqpsBAby06QKBgQDYznmvQT/xo7fgFf5oN/TUjSzv4X3K5oXD\nVorNs82yBYrVaa2+M13h/LIJmJhYjz6roKIugWDQY6lf7f68oZFxJf6WgbxUld/K\n0GpfWiVZt233P8RyADiCQH2Ro5iopoQWb9OVGJaYSax126BlNikok3hoVGeH4rrw\nI6pqBD3LHQKBgQCbi58HLuJLnQGWeyBSXWiNr5jggvBiZq4aEYLFCZshRwPsY6GN\nLuJEuQtL4Omr0MIaq2Ngw+XNhCoCdYreEyORsA/HuxYgOa8V8KngPT2P9vEFz9UD\nfU/LKxdq7VzqANutxCC+iPzHYN0FOMycfOtDlRQ7w0xhVB6vdIvytnQ5yQKBgQC5\niopM15R3oVq9JVVhr3GRbXglml5jBEE5WJjVTakdTuzvks8j1SXlPrLGz5ahQ4Wo\nr4HcNtC5xnCvLigxGjw0DwX/m+umn9Sz5wUBsU4Bp58uV54wycuSfMp5lv4QZuDn\nqq/yCubmUTaMbnan51/1367N6l3nxrugw4UV0adoaQKBgDKgTR7ocCu+aGhEe+ZJ\ngcHY2uEdXYPgnFvWR5w/bZtQnFb9psGpBCg1snUWxzxHKDxAffnQb9wL5Dglg7aj\nrecodPUJSCwawOCmtIJ4ySWETdTGmC+A7M4Bs+SXpPEA2dao4591RI9eHKCT7Igw\nXIJpPUH8TQQjQAD2EJQNcPH2\n-----END PRIVATE KEY-----\n",
			ClientEmail = "firebase-adminsdk-fbsvc@synagogail.iam.gserviceaccount.com",
			ClientId = "114659095420208221909",
			TokenUri = "https://oauth2.googleapis.com/token",
			UniverseDomain = "googleapis.com",
		};
	public static string ApiKey => "AIzaSyDeH8I0PiMfc9r4nb5AlDlWBFnfBxCE8m4";

}