using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using STEMify.Data.Interfaces;
using STEMify.Models;

namespace STEMify.Data.Repositories
{
    public class QuizQuestionRepository : Repository<QuizQuestion>, IQuizQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuizQuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddQuestionAsync(QuizQuestion question)
        {
            await _context.QuizQuestions.AddAsync(question);
        }

        public async Task<QuizQuestion> GetQuestionByIdAsync(int questionId)
        {
            return await _context.QuizQuestions.FindAsync(questionId);
        }

        public async Task<IEnumerable<QuizQuestion>> GetQuestionsByQuizIdAsync(int quizId)
        {
            return await _context.QuizQuestions
                .Where(q => q.QuizId == quizId)
                .ToListAsync();
        }

        public async Task<QuizQuestion> GetAsync(int id)
        {
            return await _context.QuizQuestions.FindAsync(id);
        }

        public async Task<IEnumerable<QuizQuestion>> GetAllAsync()
        {
            return await _context.QuizQuestions.ToListAsync();
        }

        public async Task<IEnumerable<QuizQuestion>> FindAsync(Expression<Func<QuizQuestion, bool>> predicate)
        {
            return await _context.QuizQuestions.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(QuizQuestion entity)
        {
            await _context.QuizQuestions.AddAsync(entity);
        }

        public void Update(QuizQuestion entity)
        {
            _context.QuizQuestions.Update(entity);
        }

        public void Remove(QuizQuestion entity)
        {
            _context.QuizQuestions.Remove(entity);
        }
    }
}