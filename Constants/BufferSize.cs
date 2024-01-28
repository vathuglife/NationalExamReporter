namespace NationalExamReporter.Constants;

public class BufferSize
{
    public static int STUDENT_BUFFER_SIZE = 15000;

    public static int SCORE_BUFFER_SIZE =
        STUDENT_BUFFER_SIZE * NationalExamConstants.NUMBER_OF_SUBJECTS;
}