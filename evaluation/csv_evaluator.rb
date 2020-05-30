#!/usr/bin/env ruby
# frozen_string_literal: true

require 'csv'
require 'time'

def avg(array, round = nil)
  value = array.sum(0.0) / array.size
  round ? value.round(round) : value
end

def median(array)
  sorted = array.sort
  len = sorted.length
  (sorted[(len - 1) / 2] + sorted[len / 2]) / 2
end

files = Dir['logs/*.csv']
durations = []
bees_spawned = []
bees_killed = []
sprays_spawned = []
sprays_collected = []
onions_spawned = []
onions_collected = []
new_csv_data = []

# new csv data headers
new_csv_data << %i[fileId gameLength beesSpawned beesKilled beesKillRate spraysSpawned spraysCollected spraysCollectRate onionsSpawned onionsCollected onionsCollectRate]

files.each.with_index(1) do |path, index|
  start_time = nil
  end_time = nil
  bee_spawn_count = 0
  bee_kill_count = 0
  spray_spawn_count = 0
  spray_collect_count = 0
  onion_spawn_count = 0
  onion_collect_count = 0

  CSV.foreach path, headers: true, return_headers: false do |row|
    start_time ||= Time.parse row['time']
    end_time = Time.parse row['time']
    bee_spawn_count = row['beeId'].to_i if row['beeId'].to_i > bee_spawn_count
    bee_kill_count += 1 if row['message'] == 'bee died'
    spray_spawn_count += 1 if row['message'] == 'spray spawned'
    spray_collect_count += 1 if row['message'] == 'spray collected'
    onion_spawn_count += 1 if row['message'] == 'onion spawned'
    onion_collect_count += 1 if row['message'] == 'onion collected'
  end

  # duration in seconds
  duration = end_time - start_time
  durations << duration

  bees_spawned << bee_spawn_count
  bees_killed << bee_kill_count
  bee_kill_rate = bee_spawn_count.zero? ? 0 : (bee_kill_count.to_f / bee_spawn_count).round(2)
  sprays_spawned << spray_spawn_count
  sprays_collected << spray_collect_count
  spray_collect_rate = spray_spawn_count.zero? ? 0 : (spray_collect_count.to_f / spray_spawn_count).round(2)
  onions_spawned << onion_spawn_count
  onions_collected << onion_collect_count
  onion_collect_rate = onion_spawn_count.zero? ? 0 : (onion_collect_count.to_f / onion_spawn_count).round(2)

  # set csv data
  new_csv_data << [index, duration, bee_spawn_count, bee_kill_count, bee_kill_rate, spray_spawn_count, spray_collect_count, spray_collect_rate, onion_spawn_count, onion_collect_count, onion_collect_rate]
end

avg_durations = avg(durations, 2)
avg_bee_spawns = avg(bees_spawned, 2)
avg_bee_kills = avg(bees_killed, 2)
avg_bee_percentage = ((avg_bee_kills.to_f / avg_bee_spawns) * 100).round(2)
avg_sprays_spawned = avg(sprays_spawned, 2)
avg_sprays_collected = avg(sprays_collected, 2)
avg_spray_percentage = ((avg_sprays_collected.to_f / avg_sprays_spawned) * 100).round(2)
avg_onions_spawned = avg(onions_spawned, 2)
avg_onions_collected = avg(onions_collected, 2)
avg_onion_percentage = ((avg_onions_collected.to_f / avg_onions_spawned) * 100).round(2)

printf "\e[34mAVERAGES\n"
printf "\e[0m%-25s \e[33m%s\n", 'game length', avg_durations
printf "\e[0m%-25s \e[33m%-5s \e[0m/\e[33m %-5s \e[0m> \e[32m %s%\n", 'bees spawned/killed', avg_bee_spawns, avg_bee_kills, avg_bee_percentage
printf "\e[0m%-25s \e[33m%-5s \e[0m/\e[33m %-5s \e[0m> \e[32m %s%\n", 'sprays spawned/collected', avg_sprays_spawned, avg_sprays_collected, avg_spray_percentage
printf "\e[0m%-25s \e[33m%-5s \e[0m/\e[33m %-5s \e[0m> \e[32m %s%\n", 'onions spawned/collected', avg_onions_spawned, avg_onions_collected, avg_onion_percentage
printf "\e[0m\n"

med_durations = median(durations)
med_bee_spawns = median(bees_spawned)
med_bee_kills = median(bees_killed)
med_sprays_spawned = median(sprays_spawned)
med_sprays_collected = median(sprays_collected)
med_onions_spawned = median(onions_spawned)
med_onions_collected = median(onions_collected)

printf "\e[36mMEDIANS\n"
printf "\e[0m%-25s \e[33m%s\n", 'game length', med_durations
printf "\e[0m%-25s \e[33m%-2s \e[0m/\e[33m %s\n", 'bees spawned/killed', med_bee_spawns, med_bee_kills
printf "\e[0m%-25s \e[33m%-2s \e[0m/\e[33m %s\n", 'sprays spawned/collected', med_sprays_spawned, med_sprays_collected
printf "\e[0m%-25s \e[33m%-2s \e[0m/\e[33m %s\n", 'onions spawned/collected', med_onions_spawned, med_onions_collected
printf "\e[0m\n"

# generate new CSV file
data = new_csv_data.map { |x| x.join(',') }.join("\n")
File.write('logs.csv', data)
