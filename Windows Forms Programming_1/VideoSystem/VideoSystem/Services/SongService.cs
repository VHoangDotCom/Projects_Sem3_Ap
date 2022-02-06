﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VideoSystem.Entity;
using VideoSystem.Config;

namespace VideoSystem.Services
{
    public class SongService
    {
        public void Create()
        {

        }

        public async Task<List<Song>> GetList()
        {
            List<Song> listSong = new List<Song>();
            using (HttpClient httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync($"{APIConfig.ApiDomain}{APIConfig.SongPath}");
                var content = await result.Content.ReadAsStringAsync();
                Debug.WriteLine($"Response {content} - {result.StatusCode}");
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    listSong = JsonConvert.DeserializeObject<List<Song>>(content);
                }
                else
                {
                    Debug.WriteLine("Error 500");
                }
            }
            return listSong;
        }
        public async Task<List<Song>> GetMyList()
        {
            List<Song> listSong = new List<Song>();
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {App.currentCredential.access_token}");
                var result = await httpClient.GetAsync($"{APIConfig.ApiDomain}{APIConfig.MySongPath}");
                var content = await result.Content.ReadAsStringAsync();
                Debug.WriteLine($"Response {content} - {result.StatusCode}");
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    List<Song> songs = JsonConvert.DeserializeObject<List<Song>>(content);
                }
                else
                {

                    Debug.WriteLine("Error 500");

                }

            }
            return new List<Song>();
        }
    }
}