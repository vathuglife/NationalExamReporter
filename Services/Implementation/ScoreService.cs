using System.Collections.Concurrent;

using NationalExamReporter.Constants;
using NationalExamReporter.Entities;
using NationalExamReporter.Models;
using NationalExamReporter.Services.Parameters;
using NationalExamReporter.UnitOfWork.Repositories;
using NationalExamReporter.UnitOfWork.Repositories.Implementation;

namespace NationalExamReporter.Services.Implementation;

public class ScoreService : IScoreService
{
    private ISubjectRepository? _subjectRepository;
    private CsvStudent? _csvStudent;
    private Student? _student;
    private Score[]? _scoreBuffer;

    public ScoreService()
    {
        InitializeObjects();
    }

    public List<Score> GetScoresPerStudent(ScoreServiceParameters parameters)
    {
        AssignValuesToPrivateMembers(parameters);
        List<KeyValuePair<string, double>> scoresPerCsvStudent = GetAllScoresOfCsvStudent();
        int maxScoreIndex = GetMaximumScoreIndex();
        Parallel.For((long)0,maxScoreIndex,index=>
            {
                KeyValuePair<string, double> scorePerCsvStudent = scoresPerCsvStudent[(int)index];
            Score score = new Score()
            {
                StudentId = _student!.Id,
                SubjectId = GetSubjectIdBySubjectName(scorePerCsvStudent.Key),
                ScorePerSubject = scorePerCsvStudent.Value
            };
            _scoreBuffer![index] = score;
        }
        );

        return _scoreBuffer!.ToList();
    }

    private int GetMaximumScoreIndex()
    {
        return NationalExamConstants.NUMBER_OF_SUBJECTS;
    }
    private void InitializeObjects()
    {
        
        _subjectRepository = new SubjectRepository();
        _scoreBuffer = new Score[NationalExamConstants.NUMBER_OF_SUBJECTS];
    }

    private void AssignValuesToPrivateMembers(ScoreServiceParameters parameters)
    {
        _csvStudent = parameters.CsvStudent;
        _student = parameters.Student;
    }

    private List<KeyValuePair<string, double>> GetAllScoresOfCsvStudent()
    {
        return new List<KeyValuePair<string, double>>()
        {
            new KeyValuePair<string, double>("mathematics", _csvStudent!.Mathematics),
            new KeyValuePair<string, double>("literature", _csvStudent.Literature),
            new KeyValuePair<string, double>("english", _csvStudent.English),
            new KeyValuePair<string, double>("physics", _csvStudent.Physics),
            new KeyValuePair<string, double>("chemistry", _csvStudent.Chemistry),
            new KeyValuePair<string, double>("biology", _csvStudent.Biology),
            new KeyValuePair<string, double>("history", _csvStudent.History),
            new KeyValuePair<string, double>("geography", _csvStudent.Geography),
            new KeyValuePair<string, double>("civic_education", _csvStudent.CivicEducation),
        };
    }

    private int GetSubjectIdBySubjectName(string subjectName)
    {
        return _subjectRepository!.GetSubjectIdBySubjectName(subjectName);
    }

    // private bool IsBufferMaxed()
    // {
    //     if (_scoreCount % BufferSize.SCORE_BUFFER_SIZE == 0
    //         || _scoreCount == _totalScoreCount)
    //         return true;
    //     return false;
    // }
    //
    // private ConcurrentBag<Score> RemoveDuplicatesFromBag()
    // {
    //     return new ConcurrentBag<Score>(_scoreBuffer!.
    //         GroupBy(score => score.StudentId)
    //         .Select(group => group.First()));
    // }
    // private void HandleBufferMaxed()
    // {
    //     _scoreRepository!.BulkInsertScore(_scoresPerBatch);
    // }
}