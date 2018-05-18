﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDN.Common
{
    using Microsoft.Practices.Prism.ViewModel;
    using System.Linq.Expressions;

    /// <summary>
    /// Manages validation errors for an object, notifying when the error state changes.
    /// </summary>
    /// <typeparam name="T">The type of the error object.</typeparam>
    public class ErrorsContainer<T>
    {
        private static readonly T[] noErrors = new T[0];
        private readonly Action<string> raiseErrorsChanged;
        private readonly Dictionary<string, List<T>> validationResults;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorsContainer{T}"/> class.
        /// </summary>
        /// <param name="raiseErrorsChanged">The action that invoked if when errors are added for an object./>
        /// event.</param>
        public ErrorsContainer(Action<string> raiseErrorsChanged)
        {
            if (raiseErrorsChanged == null)
            {
               // throw new ArgumentNullException("raiseErrorsChanged");
            }

            this.raiseErrorsChanged = raiseErrorsChanged;
            this.validationResults = new Dictionary<string, List<T>>();
        }

        /// <summary>
        /// Gets a value indicating whether the object has validation errors. 
        /// </summary>
        public bool HasErrors
        {
            get
            {
                return this.validationResults.Count != 0;
            }
        }

        /// <summary>
        /// Returns all the errors in the container
        /// </summary>
        /// <returns>The dictionary of errors per property.</returns>
        public Dictionary<string, List<T>> GetAllErrors()
        {
            return validationResults;
        }

        /// <summary>
        /// Gets the validation errors for a specified property.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The validation errors of type <typeparamref name="T"/> for the property.</returns>
        public IEnumerable<T> GetErrors(string propertyName)
        {
            var localPropertyName = propertyName ?? string.Empty;
            List<T> currentValidationResults = null;
            if (this.validationResults.TryGetValue(localPropertyName, out currentValidationResults))
            {
                return currentValidationResults;
            }
            else
            {
                return noErrors;
            }
        }

        /// <summary>
        /// Gets the validation errors for a specified property.
        /// </summary>
        /// <typeparam name="TProperty">The Type parameter for what the property type is. Can be inferred implicitly.</typeparam>
        /// <param name="propertyExpression">The expression indicating a property.</param>
        /// <returns>The validation errors of type <typeparamref name="T"/> for the property.</returns>
        public IEnumerable<T> GetErrors<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            return this.GetErrors(propertyName);
        }

        /// <summary>
        /// Clears the errors for the property indicated by the property expression.
        /// </summary>
        /// <typeparam name="TProperty">The property type.</typeparam>
        /// <param name="propertyExpression">The expression indicating a property.</param>
        /// <example>
        ///     container.ClearErrors(()=>SomeProperty);
        /// </example>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void ClearErrors<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            this.ClearErrors(propertyName);
        }

        /// <summary>
        /// Clears the errors for a property.
        /// </summary>
        /// <param name="propertyName">The name of th property for which to clear errors.</param>
        /// <example>
        ///     container.ClearErrors("SomeProperty");
        /// </example>
        public void ClearErrors(string propertyName)
        {
            this.SetErrors(propertyName, new List<T>());
        }

        /// <summary>
        /// Sets the validation errors for the specified property.
        /// </summary>
        /// <typeparam name="TProperty">The property type for which to set errors.</typeparam>
        /// <param name="propertyExpression">The <see cref="Expression"/> indicating the property.</param>
        /// <param name="propertyErrors">The list of errors to set for the property.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void SetErrors<TProperty>(Expression<Func<TProperty>> propertyExpression, IEnumerable<T> propertyErrors)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            this.SetErrors(propertyName, propertyErrors);
        }

        /// <summary>
        /// Sets the validation errors for the specified property.
        /// </summary>
        /// <remarks>
        /// If a change is detected then the errors changed event is raised.
        /// </remarks>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="newValidationResults">The new validation errors.</param>
        public void SetErrors(string propertyName, IEnumerable<T> newValidationResults)
        {
            var localPropertyName = propertyName ?? string.Empty;
            var hasCurrentValidationResults = this.validationResults.ContainsKey(localPropertyName);
            var hasNewValidationResults = newValidationResults != null && newValidationResults.Count() > 0;

            if (hasCurrentValidationResults || hasNewValidationResults)
            {
                if (hasNewValidationResults)
                {
                    this.validationResults[localPropertyName] = new List<T>(newValidationResults);
                    this.raiseErrorsChanged(localPropertyName);
                }
                else
                {
                    this.validationResults.Remove(localPropertyName);
                    this.raiseErrorsChanged(localPropertyName);
                }
            }
        }
    }
}