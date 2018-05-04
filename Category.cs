using System.Collections.Generic;

namespace scrape_getfpv_com
{
  public class Category
  {
    public string Name { get; set; }
    public string Link { get; set; }
    public List<Category> Children { get; set; } = new List<Category>();
    public bool Checked { get; set; } = false;
    public int HowManyItems { get; set; } = 0;
  }
}
