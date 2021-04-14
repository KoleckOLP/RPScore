private void win_s(){
    win = true;
    lost = false;
    draw = false;
}

private void lose_s(){
    lose = lose + 1;
    win = false;
    lost = true;
    draw = false;
}

private void draw_s(){
    lose = lose + 1;
    win = false;
    lost = true;
    draw = true;
}