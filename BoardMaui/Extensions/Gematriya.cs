namespace BoardMaui.Extensions;

public static class Gematriya
{
    public static string DoGematriya(int number) => ((new string[] { "", "ק", "ר", "ש", "ת", "תק", "תר", "תש", "תת", "תתק" })[number / 100] + (new string[] { "", "י", "כ", "ל", "נ", "מ", "ס", "ע", "פ", "צ" })[number % 100 / 10] + (new string[] { "", "א", "ב", "ג", "ד", "ה", "ו", "ז", "ח", "ט" })[number % 10]).Replace("יה", "טו").Replace("יו", "טז");
}