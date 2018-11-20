# PragmaticSegmenterNet #

[![Build status](https://ci.appveyor.com/api/projects/status/5jewe50doajnrckc?svg=true)](https://ci.appveyor.com/project/EliotJones/pragmaticsegmenternet)

<img src="https://raw.githubusercontent.com/UglyToad/PragmaticSegmenterNet/master/logo.png" width="128" height="128" />

This project is a direct port of [Pragmatic Segmenter](https://github.com/diasks2/pragmatic_segmenter) which provides rule-based sentence 
boundary detection.

## Usage ##

The ```Segmenter``` class provides the ```Segment``` method which in the simplest usage takes a string:

    using PragmaticSegmenterNet;
	
	IReadOnlyList<string> result = Segmenter.Segment("One Sentence. And another sentence.");
	
	// ["One Sentence.", "And another sentence."]

	IReadOnlyList<string> result2 = Segmenter.Segment("Anything.", Language.Italian);

	// ["Anything"]


The Segment method has a number of optional parameters:

	IReadOnlyList<string> Segment(string text, Language language = Language.English, bool cleanText = true, DocumentType documentType = DocumentType.Any)

+ Language - An enum representing the supported languages, the default is English, see the supported languages list below for the list of currently supported languages.
+ CleanText - A boolean indicating whether the input text should be cleaned prior to segmentation. Cleaning removes extra newlines and whitespace. Defaults to ```true```.
+ DocumentType - Used by the text cleaning process to determine which reformatting to apply. For PDFs this handles newlines in the middle of a sentence whereas for HTML documents this will handle HMTL tags. Defaults to any which does not apply any special formatting.

## Languages ##

+ English = 0 (default)
+ Amharic = 1
+ Arabic = 2
+ Armenian = 3
+ Bulgarian = 4
+ Burmese = 5
+ Chinese = 6
+ Danish = 7
+ Dutch = 8
+ French = 9
+ German = 10
+ Greek = 11
+ Hindi = 12
+ Italian = 13
+ Japanese = 14
+ Kazakh = 15 (partial support, potentially only for the Cyrillic form of the alphabet)
+ Persian = 16
+ Polish = 17
+ Russian = 18
+ Spanish = 19
+ Urdu = 20

## Credit ##

This project wouldn't be possible without the work done by [Pragmatic Segmenter](https://github.com/diasks2/pragmatic_segmenter) team. Any bugs in the code are entirely my fault.
