
using OpenCVForUnity.CoreModule;
using OpenCVForUnity.UtilsModule;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenCVForUnity.Img_hashModule
{
    // C++: class Img_hash


    public class Img_hash
    {

        // C++: enum cv.img_hash.BlockMeanHashMode
        public const int BLOCK_MEAN_HASH_MODE_0 = 0;
        public const int BLOCK_MEAN_HASH_MODE_1 = 1;
        //
        // C++:  void cv::img_hash::averageHash(Mat inputArr, Mat& outputArr)
        //

        /**
         @brief Calculates img_hash::AverageHash in one call
         @param inputArr input image want to compute hash value, type should be CV_8UC4, CV_8UC3 or CV_8UC1.
         @param outputArr Hash value of input, it will contain 16 hex decimal number, return type is CV_8U
         */
        public static void averageHash(Mat inputArr, Mat outputArr)
        {
            if (inputArr != null) inputArr.ThrowIfDisposed();
            if (outputArr != null) outputArr.ThrowIfDisposed();

            img_1hash_Img_1hash_averageHash_10(inputArr.nativeObj, outputArr.nativeObj);


        }


        //
        // C++:  void cv::img_hash::blockMeanHash(Mat inputArr, Mat& outputArr, int mode = BLOCK_MEAN_HASH_MODE_0)
        //

        /**
         @brief Computes block mean hash of the input image
             @param inputArr input image want to compute hash value, type should be CV_8UC4, CV_8UC3 or CV_8UC1.
             @param outputArr Hash value of input, it will contain 16 hex decimal number, return type is CV_8U
             @param mode the mode
         */
        public static void blockMeanHash(Mat inputArr, Mat outputArr, int mode)
        {
            if (inputArr != null) inputArr.ThrowIfDisposed();
            if (outputArr != null) outputArr.ThrowIfDisposed();

            img_1hash_Img_1hash_blockMeanHash_10(inputArr.nativeObj, outputArr.nativeObj, mode);


        }

        /**
         @brief Computes block mean hash of the input image
             @param inputArr input image want to compute hash value, type should be CV_8UC4, CV_8UC3 or CV_8UC1.
             @param outputArr Hash value of input, it will contain 16 hex decimal number, return type is CV_8U
             @param mode the mode
         */
        public static void blockMeanHash(Mat inputArr, Mat outputArr)
        {
            if (inputArr != null) inputArr.ThrowIfDisposed();
            if (outputArr != null) outputArr.ThrowIfDisposed();

            img_1hash_Img_1hash_blockMeanHash_11(inputArr.nativeObj, outputArr.nativeObj);


        }


        //
        // C++:  void cv::img_hash::colorMomentHash(Mat inputArr, Mat& outputArr)
        //

        /**
         @brief Computes color moment hash of the input, the algorithm
             is come from the paper "Perceptual  Hashing  for  Color  Images
             Using  Invariant Moments"
             @param inputArr input image want to compute hash value,
             type should be CV_8UC4, CV_8UC3 or CV_8UC1.
             @param outputArr 42 hash values with type CV_64F(double)
         */
        public static void colorMomentHash(Mat inputArr, Mat outputArr)
        {
            if (inputArr != null) inputArr.ThrowIfDisposed();
            if (outputArr != null) outputArr.ThrowIfDisposed();

            img_1hash_Img_1hash_colorMomentHash_10(inputArr.nativeObj, outputArr.nativeObj);


        }


        //
        // C++:  void cv::img_hash::marrHildrethHash(Mat inputArr, Mat& outputArr, float alpha = 2.0f, float scale = 1.0f)
        //

        /**
         @brief Computes average hash value of the input image
             @param inputArr input image want to compute hash value,
             type should be CV_8UC4, CV_8UC3, CV_8UC1.
             @param outputArr Hash value of input, it will contain 16 hex
             decimal number, return type is CV_8U
             @param alpha int scale factor for marr wavelet (default=2).
             @param scale int level of scale factor (default = 1)
         */
        public static void marrHildrethHash(Mat inputArr, Mat outputArr, float alpha, float scale)
        {
            if (inputArr != null) inputArr.ThrowIfDisposed();
            if (outputArr != null) outputArr.ThrowIfDisposed();

            img_1hash_Img_1hash_marrHildrethHash_10(inputArr.nativeObj, outputArr.nativeObj, alpha, scale);


        }

        /**
         @brief Computes average hash value of the input image
             @param inputArr input image want to compute hash value,
             type should be CV_8UC4, CV_8UC3, CV_8UC1.
             @param outputArr Hash value of input, it will contain 16 hex
             decimal number, return type is CV_8U
             @param alpha int scale factor for marr wavelet (default=2).
             @param scale int level of scale factor (default = 1)
         */
        public static void marrHildrethHash(Mat inputArr, Mat outputArr, float alpha)
        {
            if (inputArr != null) inputArr.ThrowIfDisposed();
            if (outputArr != null) outputArr.ThrowIfDisposed();

            img_1hash_Img_1hash_marrHildrethHash_11(inputArr.nativeObj, outputArr.nativeObj, alpha);


        }

        /**
         @brief Computes average hash value of the input image
             @param inputArr input image want to compute hash value,
             type should be CV_8UC4, CV_8UC3, CV_8UC1.
             @param outputArr Hash value of input, it will contain 16 hex
             decimal number, return type is CV_8U
             @param alpha int scale factor for marr wavelet (default=2).
             @param scale int level of scale factor (default = 1)
         */
        public static void marrHildrethHash(Mat inputArr, Mat outputArr)
        {
            if (inputArr != null) inputArr.ThrowIfDisposed();
            if (outputArr != null) outputArr.ThrowIfDisposed();

            img_1hash_Img_1hash_marrHildrethHash_12(inputArr.nativeObj, outputArr.nativeObj);


        }


        //
        // C++:  void cv::img_hash::pHash(Mat inputArr, Mat& outputArr)
        //

        /**
         @brief Computes pHash value of the input image
             @param inputArr input image want to compute hash value,
              type should be CV_8UC4, CV_8UC3, CV_8UC1.
             @param outputArr Hash value of input, it will contain 8 uchar value
         */
        public static void pHash(Mat inputArr, Mat outputArr)
        {
            if (inputArr != null) inputArr.ThrowIfDisposed();
            if (outputArr != null) outputArr.ThrowIfDisposed();

            img_1hash_Img_1hash_pHash_10(inputArr.nativeObj, outputArr.nativeObj);


        }


        //
        // C++:  void cv::img_hash::radialVarianceHash(Mat inputArr, Mat& outputArr, double sigma = 1, int numOfAngleLine = 180)
        //

        /**
         @brief Computes radial variance hash of the input image
             @param inputArr input image want to compute hash value,
             type should be CV_8UC4, CV_8UC3, CV_8UC1.
             @param outputArr Hash value of input
             @param sigma Gaussian kernel standard deviation
             @param numOfAngleLine The number of angles to consider
         */
        public static void radialVarianceHash(Mat inputArr, Mat outputArr, double sigma, int numOfAngleLine)
        {
            if (inputArr != null) inputArr.ThrowIfDisposed();
            if (outputArr != null) outputArr.ThrowIfDisposed();

            img_1hash_Img_1hash_radialVarianceHash_10(inputArr.nativeObj, outputArr.nativeObj, sigma, numOfAngleLine);


        }

        /**
         @brief Computes radial variance hash of the input image
             @param inputArr input image want to compute hash value,
             type should be CV_8UC4, CV_8UC3, CV_8UC1.
             @param outputArr Hash value of input
             @param sigma Gaussian kernel standard deviation
             @param numOfAngleLine The number of angles to consider
         */
        public static void radialVarianceHash(Mat inputArr, Mat outputArr, double sigma)
        {
            if (inputArr != null) inputArr.ThrowIfDisposed();
            if (outputArr != null) outputArr.ThrowIfDisposed();

            img_1hash_Img_1hash_radialVarianceHash_11(inputArr.nativeObj, outputArr.nativeObj, sigma);


        }

        /**
         @brief Computes radial variance hash of the input image
             @param inputArr input image want to compute hash value,
             type should be CV_8UC4, CV_8UC3, CV_8UC1.
             @param outputArr Hash value of input
             @param sigma Gaussian kernel standard deviation
             @param numOfAngleLine The number of angles to consider
         */
        public static void radialVarianceHash(Mat inputArr, Mat outputArr)
        {
            if (inputArr != null) inputArr.ThrowIfDisposed();
            if (outputArr != null) outputArr.ThrowIfDisposed();

            img_1hash_Img_1hash_radialVarianceHash_12(inputArr.nativeObj, outputArr.nativeObj);


        }


#if (UNITY_IOS || UNITY_WEBGL) && !UNITY_EDITOR
        const string LIBNAME = "__Internal";
#else
        const string LIBNAME = "opencvforunity";
#endif



        // C++:  void cv::img_hash::averageHash(Mat inputArr, Mat& outputArr)
        [DllImport(LIBNAME)]
        private static extern void img_1hash_Img_1hash_averageHash_10(IntPtr inputArr_nativeObj, IntPtr outputArr_nativeObj);

        // C++:  void cv::img_hash::blockMeanHash(Mat inputArr, Mat& outputArr, int mode = BLOCK_MEAN_HASH_MODE_0)
        [DllImport(LIBNAME)]
        private static extern void img_1hash_Img_1hash_blockMeanHash_10(IntPtr inputArr_nativeObj, IntPtr outputArr_nativeObj, int mode);
        [DllImport(LIBNAME)]
        private static extern void img_1hash_Img_1hash_blockMeanHash_11(IntPtr inputArr_nativeObj, IntPtr outputArr_nativeObj);

        // C++:  void cv::img_hash::colorMomentHash(Mat inputArr, Mat& outputArr)
        [DllImport(LIBNAME)]
        private static extern void img_1hash_Img_1hash_colorMomentHash_10(IntPtr inputArr_nativeObj, IntPtr outputArr_nativeObj);

        // C++:  void cv::img_hash::marrHildrethHash(Mat inputArr, Mat& outputArr, float alpha = 2.0f, float scale = 1.0f)
        [DllImport(LIBNAME)]
        private static extern void img_1hash_Img_1hash_marrHildrethHash_10(IntPtr inputArr_nativeObj, IntPtr outputArr_nativeObj, float alpha, float scale);
        [DllImport(LIBNAME)]
        private static extern void img_1hash_Img_1hash_marrHildrethHash_11(IntPtr inputArr_nativeObj, IntPtr outputArr_nativeObj, float alpha);
        [DllImport(LIBNAME)]
        private static extern void img_1hash_Img_1hash_marrHildrethHash_12(IntPtr inputArr_nativeObj, IntPtr outputArr_nativeObj);

        // C++:  void cv::img_hash::pHash(Mat inputArr, Mat& outputArr)
        [DllImport(LIBNAME)]
        private static extern void img_1hash_Img_1hash_pHash_10(IntPtr inputArr_nativeObj, IntPtr outputArr_nativeObj);

        // C++:  void cv::img_hash::radialVarianceHash(Mat inputArr, Mat& outputArr, double sigma = 1, int numOfAngleLine = 180)
        [DllImport(LIBNAME)]
        private static extern void img_1hash_Img_1hash_radialVarianceHash_10(IntPtr inputArr_nativeObj, IntPtr outputArr_nativeObj, double sigma, int numOfAngleLine);
        [DllImport(LIBNAME)]
        private static extern void img_1hash_Img_1hash_radialVarianceHash_11(IntPtr inputArr_nativeObj, IntPtr outputArr_nativeObj, double sigma);
        [DllImport(LIBNAME)]
        private static extern void img_1hash_Img_1hash_radialVarianceHash_12(IntPtr inputArr_nativeObj, IntPtr outputArr_nativeObj);

    }
}
