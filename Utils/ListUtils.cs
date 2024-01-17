namespace NationalExamReporter.Utils;

public static class ListUtils
{
    public static bool IsListNullOrEmpty(IEnumerable<Object> list)
    {
        if (list == null)
        {
            return true;
        }

        return list.Any() == false;
    }
}