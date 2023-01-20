﻿namespace BookWebStore.Domain.Constants
{
    public class Errors
    {
        public const string CategoryNotFound = "Category not found";
        public const string CategoryAddingError = "Error while adding category";
        public const string CategorySameNumber = "The order's number cannot exactly match the same name";
        public const string CategoryDoesNotExist = "Category doesn't exist";

        public const string CoverTypeNotFound = "Cover type not found";
        public const string CoverTypeAddingError = "Error while adding cover type";
        public const string CoverTypeDoesNotExist = "Cover type doesn't exist";
    }
}
