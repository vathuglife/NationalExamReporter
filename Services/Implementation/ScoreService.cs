﻿using NationalExamReporter.Constants;
using NationalExamReporter.Entities;
using NationalExamReporter.Models;
using NationalExamReporter.Services.Parameters;
using NationalExamReporter.UnitOfWork.Repositories;
using NationalExamReporter.UnitOfWork.Repositories.Implementation;

namespace NationalExamReporter.Services.Implementation;

public class ScoreService : IScoreService
{
    private IScoreRepository? _scoreRepository;
    private ISubjectRepository? _subjectRepository;
    private List<Score>? _scoreBufferList;
    private CsvStudent? _csvStudent;
    private Student? _student;
    private int _scoreCount;
    private int _totalScoreCount;

    public ScoreService()
    {
        InitializeObjects();
    }

    public void InsertStudentScoreToScoreTable(ScoreServiceParameters parameters)
    {
        AssignValuesToPrivateMembers(parameters);
        List<KeyValuePair<string, double>> scoresPerCsvStudent = GetAllScoresOfCsvStudent();
        
        foreach (KeyValuePair<string,double> scorePerCsvStudent in scoresPerCsvStudent)
        {
            Score score = new Score()
            {
                StudentId = _student!.Id,
                SubjectId = GetSubjectIdBySubjectName(scorePerCsvStudent.Key),
                ScorePerSubject = scorePerCsvStudent.Value 
            };
            _scoreBufferList!.Add(score);
            _scoreCount++;
            if(IsBufferMaxed()) HandleBufferMaxed();
        }
    }

    private void InitializeObjects()
    {
        _scoreRepository = new ScoreRepository();
        _subjectRepository = new SubjectRepository();
        _scoreBufferList = new List<Score>();
        _scoreCount = 0;
        _totalScoreCount = 0;
    }

    private void AssignValuesToPrivateMembers(ScoreServiceParameters parameters)
    {
        _csvStudent = parameters.CsvStudent;
        _student = parameters.Student;
        _totalScoreCount = parameters.TotalScoreCount;
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
    private bool IsBufferMaxed()
    {
        if (_scoreCount % BufferSize.SCORE_BUFFER_SIZE == 0
            || _scoreCount==_totalScoreCount) 
            return true;
        return false;
    }

    private void HandleBufferMaxed()
    {
        _scoreRepository!.BulkInsertScore(_scoreBufferList!);
        _scoreBufferList!.Clear();
    }
}