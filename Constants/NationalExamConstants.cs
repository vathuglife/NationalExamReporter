namespace NationalExamReporter.Constants;

public class NationalExamConstants
{
    public static readonly List<KeyValuePair<string, int>> Years = new()
    {
        new KeyValuePair<string, int>("2010", 2010),
        new KeyValuePair<string, int>("2011", 2011),
        new KeyValuePair<string, int>("2012", 2012),
        new KeyValuePair<string, int>("2013", 2013),
        new KeyValuePair<string, int>("2014", 2014),
        new KeyValuePair<string, int>("2015", 2015),
        new KeyValuePair<string, int>("2016", 2016),
        new KeyValuePair<string, int>("2017", 2017),
        new KeyValuePair<string, int>("2018", 2018),
        new KeyValuePair<string, int>("2019", 2019),
        new KeyValuePair<string, int>("2020", 2020),
        new KeyValuePair<string, int>("2021", 2021),
        new KeyValuePair<string, int>("2022", 2022),
        new KeyValuePair<string, int>("2023", 2023)
    };

    public static readonly Dictionary<string, string> ExamGroups = new()
    {
        { "A00", "Toán, Lý, Hóa" },
        { "B00", "Toán, Hóa, Sinh" },
        { "C00", "Văn, Sử, Địa" },
        { "D00", "Toán, Văn, Anh" },
        { "A01", "Toán, Lý, Anh"}
    };

    public static int NUMBER_OF_SUBJECTS = 9;
}