﻿using NationalExamReporter.Entities;

namespace NationalExamReporter.UnitOfWork.Repositories;

public interface IScoreRepository
{
    void InsertNewScore(Score score);
    void BulkInsertScore(IEnumerable<Score> scores);
}