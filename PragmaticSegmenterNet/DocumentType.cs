namespace PragmaticSegmenterNet
{
    /// <summary>
    /// Determines which text cleaning rules to apply based on common patterns in malformed text from each source.
    /// </summary>
    public enum DocumentType
    {
        /// <summary>
        /// Apply the normal text cleaning rules. 
        /// </summary>
        Any = 0,
        /// <summary>
        /// Apply most normal rules but also target new-lines mid-sentence.
        /// </summary>
        Pdf = 1
    }
}