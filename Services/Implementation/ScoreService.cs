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
    private IScoreRepository? _scoreRepository;
    private CsvStudent? _csvStudent;
    private Student? _student;
    private List<Score>? _scoreBuffer;
    private int _bufferIndex;
    private int _scoreIndex;

    public ScoreService(int totalScoreCount)
    {
        InitializeObjects();
    }

    public void InsertScoresPerStudent(ScoreServiceParameters parameters)
    {
        AssignValuesToPrivateMembers(parameters);
        List<KeyValuePair<string, double>> scoresPerCsvStudent
            = GetAllScoresOfCsvStudent();
        
        // Parallel.For((long)0,
        
        //     parallelIndex =>
        //     {
        foreach (KeyValuePair<string, double> scorePerCsvStudent in scoresPerCsvStudent)
        {
            Score score = new Score()
            {
                StudentId = _student!.Id,
                SubjectId = GetSubjectIdBySubjectName(scorePerCsvStudent.Key),
                ScorePerSubject = scorePerCsvStudent.Value
            };
            _scoreBuffer.Add(score);
            _bufferIndex++;
        }        
       
            // });
        
    }

    private int GetToIndexByBufferSize()
    {
        return _scoreIndex + BufferSize.SCORE_BUFFER_SIZE;
    }

    private void InitializeObjects()
    {
        _subjectRepository = new SubjectRepository();
        // _scoreBuffer = new Score[BufferSize.SCORE_BUFFER_SIZE];
        _scoreBuffer = new List<Score>();
        _scoreRepository = new ScoreRepository();

        _scoreIndex = 0;
        _bufferIndex = 0;
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

    public void HandleBufferMaxed()
    {
        _scoreRepository!.BulkInsertScore(_scoreBuffer!.ToList()!);
        _bufferIndex = 0;
        _scoreBuffer!.Clear();
    }

    private void UpdateCurrentIndex()
    {
        _scoreIndex = GetToIndexByBufferSize();
    }
}