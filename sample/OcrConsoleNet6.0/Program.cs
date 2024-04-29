﻿using OpenCvSharp;
using OpenVinoSharp.Extensions.model.PaddleOCR;

namespace OcrConsoleNet6._0
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            OnlineOcr ocr = await Pipeline.GetOnlineOCR(Language.ch_PP_OCRv4);
            Tuple<List<OCRPredictResult>, Mat> ocr_result = ocr.ocr_test();
            PaddleOcrUtility.print_result(ocr_result.Item1);
            Mat image = PaddleOcrUtility.visualize_bboxes(ocr_result.Item2, ocr_result.Item1);
            Cv2.ImShow("Result", image);
            Cv2.WaitKey(0);
        }
    }
}
