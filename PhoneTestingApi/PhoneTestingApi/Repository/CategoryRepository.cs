﻿using Microsoft.EntityFrameworkCore;
using PhoneTestingApi.Data;
using PhoneTestingApi.Interface;
using PhoneTestingApi.Models;

namespace PhoneTestingApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CategoriesExists(int CategoryId)
        {
            return _context.categories.Any(c => c.Id == CategoryId);
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

        public ICollection<Category> GetAllCategories()
        {
            return _context.categories.OrderBy(c => c.Id).ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public Category GetCategoryByPhoneType(string PhoneType)
        {
            var phones = _context.phones.Where(p => p.Category.PhoneType == PhoneType).FirstOrDefault();
            return phones.Category;
        }

        public ICollection<Phone> GetPhonesByCategory(int CategoryId)
        {
            var phones = _context.phones.Include(p => p.Category).Where(ph => ph.Category.Id == CategoryId).ToList();
            return phones;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
