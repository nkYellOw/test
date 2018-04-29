using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using static System.Net.WebRequestMethods;

namespace scrape_getfpv_com
{
    
    class Net
  {
    CookieContainer cookie = new CookieContainer();
    public Encoding Encoding { get; set; } = Encoding.UTF8;
    public string ResponseUri { get; set; }

    public string GET(string link, Dictionary<string, object> data = null,
                               NameValueCollection headers = null, string payloadData = null,string Proxy="",int downloadDelay=0)
    {
      using (var wc = new CookieWebClient())
      {
        wc.CookieContainer = cookie;
        wc.Encoding = Encoding;

                if (!string.IsNullOrEmpty(Proxy))
                {
                    WebProxy webProxy = new WebProxy(Proxy, true);
                    webProxy.UseDefaultCredentials = true;
                    wc.Proxy = webProxy;

                }

        if (headers != null)
        {
          for (int i = 0; i < headers.Count; i++)
                    {
                        Sleep(downloadDelay);

                        switch (headers.GetKey(i).ToLower())
                        {
                            case "accept":
                                wc.Headers.Add(HttpRequestHeader.Accept, headers.Get(i));
                                break;
                            case "content-type":
                                wc.Headers.Add(HttpRequestHeader.ContentType, headers.Get(i));
                                break;
                            case "referer":
                                wc.Headers.Add(HttpRequestHeader.Referer, headers.Get(i));
                                break;
                            case "host":
                                wc.Headers.Add(HttpRequestHeader.Host, headers.Get(i));
                                break;
                            case "connection":
                                if (headers.Get(i) == "keep-alive")
                                {
                                    wc.Headers.Add(HttpRequestHeader.KeepAlive, "true");
                                }
                                else
                                {
                                    wc.Headers.Add(HttpRequestHeader.Connection, headers.Get(i));
                                }
                                break;
                            case "content-length":
                                wc.Headers.Add(HttpRequestHeader.ContentLength, headers.Get(i).ToString());
                                break;
                            case "user-agent":
                                wc.Headers.Add(HttpRequestHeader.UserAgent, headers.Get(i));
                                Console.WriteLine(headers.Get(i));
                                break;
                            default:
                                wc.Headers.Add(headers.GetKey(i), headers.Get(i).ToString());
                                break;
                        }
                    }
                }

        string dataStr = "";
        if (data != null)
        {
          dataStr = "?" + Func.DictionaryToUrlParam(data);
        }
        
        string res = wc.DownloadString(link + dataStr);
        ResponseUri = wc.ResponseUri.ToString();
        cookie = wc.CookieContainer;
        return res;
      }
    }

        private static void Sleep(int downloadDelay)
        {
            System.Threading.Thread.Sleep(downloadDelay);
        }

        public string POST(string link, Dictionary<string, object> data = null,
                                NameValueCollection headers = null, string payloadData = null)
    {
      using (var wc = new CookieWebClient())
      {
        wc.CookieContainer = cookie;
        wc.Encoding = Encoding;

        //wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");
        if (headers != null)
        {
          for (int i = 0; i < headers.Count; i++)
          {
            switch (headers.GetKey(i).ToLower())
            {
              case "accept":
                wc.Headers.Add(HttpRequestHeader.Accept, headers.Get(i));
                break;
              case "content-type":
                wc.Headers.Add(HttpRequestHeader.ContentType, headers.Get(i));
                break;
              case "referer":
                wc.Headers.Add(HttpRequestHeader.Referer, headers.Get(i));
                break;
              case "host":
                wc.Headers.Add(HttpRequestHeader.Host, headers.Get(i));
                break;
              case "connection":
                if (headers.Get(i) == "keep-alive")
                {
                  wc.Headers.Add(HttpRequestHeader.KeepAlive, "true");
                }
                else
                {
                  wc.Headers.Add(HttpRequestHeader.Connection, headers.Get(i));
                }
                break;
              case "content-length":
                wc.Headers.Add(HttpRequestHeader.ContentLength, headers.Get(i).ToString());
                break;
              case "user-agent":            
                wc.Headers.Add(HttpRequestHeader.UserAgent, headers.Get(i));
                                Console.WriteLine(headers.Get(i));
                break;
              default:
                wc.Headers.Add(headers.GetKey(i), headers.Get(i).ToString());
                break;
            }
          }
        }

        string res = "";
        if (data != null)
        {
          string dataStr = Func.DictionaryToUrlParam(data);
          res = wc.UploadString(new Uri(link), "POST", dataStr);
        }
        else if (data == null && !string.IsNullOrEmpty(payloadData))
        {
          res = wc.UploadString(new Uri(link), "POST", payloadData);
        }

        cookie = wc.CookieContainer;
        return res;
      }
    }

    public void DownloadFile(string link, string filePath)
    {
      using (var wc = new CookieWebClient())
      {
               // if (!System.IO.File.Exists(filePath))
               // {
                    wc.DownloadFile(link, filePath);
                //}
      }
    }
  }
}

public class CookieWebClient : WebClient
{
  private CookieContainer m_container = new CookieContainer();
  public CookieContainer CookieContainer
  {
    get { return this.m_container; }
    set { this.m_container = value; }
  }

  private Uri _responseUri;
  public Uri ResponseUri
  {
    get { return _responseUri; }
  }

  protected override WebResponse GetWebResponse(WebRequest request)
  {
        WebResponse response = null;
    try
        {
            response = base.GetWebResponse(request);
            _responseUri = response.ResponseUri;
        }
        catch(WebException e)
        {
            Console.WriteLine("");
            Console.WriteLine(e.Message);
            Console.WriteLine("");
            //    var
        }

    
    return response;
  }


  protected override WebRequest GetWebRequest(Uri address)
  {
        WebRequest request = base.GetWebRequest(address);
    if (request is HttpWebRequest)
    {
      (request as HttpWebRequest).CookieContainer = m_container;
    }
    return request;
  }
}
