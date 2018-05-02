﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewLibrary.Models
{
    public class Review
    {
        public int ID { get; }
        public int RestID { get; set; }
        public string Reviewer { get; set; }
        public string Text { get; set; }
        public double Rating { get; set; }

        public Review(string submitter, string newText, double rating)
        {
            Reviewer = submitter;
            Text = newText;
            Rating = rating;
        }

        public void EditReview(string _text, double _rating)
        {
            Text = _text;
            Rating = _rating;
        }
    }
}
