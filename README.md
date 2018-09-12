# PragmaticSegmenterNet #

[![Build status](https://ci.appveyor.com/api/projects/status/5jewe50doajnrckc?svg=true)](https://ci.appveyor.com/project/EliotJones/pragmaticsegmenternet)

This project is a direct port of [Pragmatic Segmenter](https://github.com/diasks2/pragmatic_segmenter) which provides rule-based sentence 
boundary detection.

## Usage ##

The ```Segmenter``` class provides the ```Segment``` method which in the simplest usage takes a string:

    using PragmaticSegmenterNet;
	
	IReadOnlyList<string> result = Segmenter.Segment("One Sentence. And another sentence.");
	
	// ["One Sentence.", "And another sentence."]
	

## Credit ##

This project wouldn't be possible without the work done by [Pragmatic Segmenter](https://github.com/diasks2/pragmatic_segmenter) team. Any bugs in the code are entirely my fault.
