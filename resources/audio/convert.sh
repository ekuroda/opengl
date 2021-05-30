for f in `ls *.mp3`; do
    oggfile=$(echo $f | sed -e 's/.mp3/.ogg/g')
    echo "convert $f to $oggfile"
    ffmpeg -y -i "$f"  -strict -2 -acodec vorbis -ac 2 -aq 50 "$oggfile"
done
