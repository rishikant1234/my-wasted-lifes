
  :root{
    --paper:#EFE6D2; --paper-dark:#E3D6B8; --card:#F6EFDD;
    --ink:#362619; --ink-soft:#5C4632;
    --forest:#33513E; --forest-dark:#24392C;
    --rust:#BD5B2A; --mustard:#C99A3E; --cork:#C48A55;
  }

  
  .dark{
    --paper:#241C13; --paper-dark:#1B150E; --card:#2E2417;
    --ink:#EEE2C9; --ink-soft:#C7B593;
    --forest:#7FB394; --forest-dark:#5C8A6E;
    --rust:#E2884E; --mustard:#DBB268; --cork:#8A5F3C;
  }
  *{box-sizing:border-box;}
  html,body {
    margin:0;
    padding:0;
    background:var(--paper);
    color:var(--ink);
    transition:background .35s ease,color .35s ease;
  }
  body {
    font-family:'Lora',Georgia,serif;
    -webkit-font-smoothing:antialiased;
  }
  a{color:inherit;}
  button,input,textarea {
    font-family:inherit;
    color:inherit;
  }
  button{cursor:pointer;}
  img {
    max-width:100%;
    display:block;
  }
  .hand{font-family:'Caveat','Segoe Script',cursive;}
  .mono{font-family:'JetBrains Mono',ui-monospace,Menlo,monospace;}

  .app-shell{min-height:100vh;}

  
  .paper-texture{
    background-image:
      radial-gradient(circle at 20% 20%, rgba(0,0,0,0.045) 0, transparent 40%),
      radial-gradient(circle at 80% 60%, rgba(0,0,0,0.045) 0, transparent 45%),
      repeating-linear-gradient(0deg, rgba(0,0,0,0.012) 0px, rgba(0,0,0,0.012) 1px, transparent 1px, transparent 3px);
  }

  .row {
    display:flex;
    align-items:center;
  }
  .g-xs{gap:.4rem;}
  .grow {
    flex:1 1 auto;
    min-width:0;
  }
  .wfull{width:100%;}
  .hide{display:none !important;}


  
  .wrap {
    max-width:1080px;
    margin:0 auto;
    padding:0 20px;
  }
  .wrap-narrow {
    max-width:740px;
    margin:0 auto;
    padding:0 20px;
  }


  
  .site-header {
    position:sticky;
    top:0;
    z-index:30;
    background:var(--paper);
    border-bottom:1px solid var(--cork);
  }
  .site-header-inner {
    max-width:1080px;
    margin:0 auto;
    padding:12px 20px;
    display:flex;
    align-items:center;
    justify-content:space-between;
  }
  .logo {
    font-size:1.7rem;
    background:none;
    border:none;
    padding:0;
  }
  .logo:hover{color:var(--rust);}
  .nav {
    display:flex;
    align-items:center;
    gap:8px;
  }
  @media(min-width:640px){ .nav{gap:16px;} }

  .navlink {
    background:none;
    border:none;
    padding:6px 12px;
    border-radius:6px;
    font-size:.8rem;
    letter-spacing:.02em;
  }
  .icon-btn {
    width:34px;
    height:34px;
    border-radius:6px;
    border:1px solid color-mix(in srgb, var(--ink) 25%, transparent);
    background:none;
    font-size:.85rem;
  }
  .navlink:hover, .icon-btn:hover{background:var(--paper-dark);}
  .hello {
    font-size:.75rem;
    color:var(--ink-soft);
    display:none;
  }
  @media(min-width:640px){ .hello{display:inline;} }


  
  .btn {
    font-family:'JetBrains Mono',monospace;
    letter-spacing:.02em;
    border:none;
    border-radius:6px;
    padding:11px 22px;
    font-size:.82rem;
    transition:filter .15s, transform .1s;
    box-shadow:2px 2px 0 rgba(0,0,0,.14);
  }
  .btn:active{transform:scale(.97);}
  .btn-primary {
    background:var(--rust);
    color:#fff8ee;
  }
  .btn-forest {
    background:var(--forest);
    color:#fbf6e8;
  }
  .btn-primary:hover, .btn-forest:hover{filter:brightness(1.1);}
  .btn-outline {
    background:transparent;
    border:2px solid var(--ink);
    color:var(--ink);
    box-shadow:none;
  }
  .btn-ghost {
    background:transparent;
    border:1px solid color-mix(in srgb, var(--ink) 30%, transparent);
    color:var(--ink);
    border-radius:6px;
    padding:8px 16px;
    box-shadow:none;
  }
  .btn-outline:hover, .btn-ghost:hover{background:var(--paper-dark);}
  .btn-sm {
    padding:8px 16px;
    font-size:.72rem;
  }
  .btn:disabled {
    opacity:.6;
    cursor:not-allowed;
  }


  
  .hero {
    position:relative;
    overflow:hidden;
    text-align:center;
    padding:70px 20px 56px;
  }
  .hero-bg-emoji {
    position:absolute;
    inset:0;
    opacity:.06;
    font-size:220px;
    line-height:1;
    display:flex;
    align-items:center;
    justify-content:flex-end;
    padding-right:40px;
    pointer-events:none;
  }
  .hero-inner {
    position:relative;
    max-width:640px;
    margin:0 auto;
  }
  .hero-title {
    font-size:clamp(2.6rem,7vw,4.6rem);
    line-height:1.05;
    margin:0;
  }
  .hero-sub {
    margin-top:20px;
    color:var(--ink-soft);
    font-size:1.05rem;
    line-height:1.6;
  }
  .hero-actions {
    margin-top:30px;
    display:flex;
    flex-wrap:wrap;
    gap:14px;
    justify-content:center;
  }


  
  .board-head {
    display:flex;
    align-items:center;
    justify-content:space-between;
    flex-wrap:wrap;
    gap:12px;
    margin-bottom:24px;
  }
  .section-title {
    font-size:1.8rem;
    color:var(--forest);
    margin:0;
  }
  .search-input {
    font-family:'JetBrains Mono',monospace;
    font-size:.8rem;
    padding:9px 16px;
    border-radius:6px;
    border:1px solid color-mix(in srgb, var(--ink) 25%, transparent);
    background:var(--paper-dark);
    width:220px;
    max-width:100%;
  }
  .cork {
    background-color:var(--cork);
    border-radius:14px;
    padding:34px 22px;
    box-shadow:0 4px 10px rgba(0,0,0,.15);
  }
  @media(min-width:640px){ .cork{padding:40px;} }
  .hobby-grid {
    display:grid;
    grid-template-columns:repeat(2,1fr);
    gap:30px 24px;
  }
  @media(min-width:560px){ .hobby-grid{grid-template-columns:repeat(3,1fr);} }
  @media(min-width:860px){ .hobby-grid{grid-template-columns:repeat(4,1fr);} }
  .pin-wrap{position:relative;}

  
  .pin{position:absolute; top:-11px; left:50%; transform:translateX(-50%); width:16px; height:16px; border-radius:50%;
       background:radial-gradient(circle at 35% 30%, #e9836b, #b23f24 70%); box-shadow:0 2px 3px rgba(0,0,0,.4); z-index:5;}
  .hobby-card {
    position:relative;
    display:block;
    width:100%;
    text-align:left;
    background:var(--card);
    border:1px solid color-mix(in srgb, var(--ink) 12%, transparent);
    border-radius:8px;
    padding:18px;
    box-shadow:2px 3px 0 rgba(0,0,0,.13);
    transition:transform .12s;
  }
  .hobby-card:hover{transform:translateY(-3px);}
  .washi {
    position:absolute;
    top:-8px;
    right:14px;
    width:46px;
    height:20px;
    background:color-mix(in srgb, var(--mustard) 65%, transparent);
    transform:rotate(-4deg);
    box-shadow:0 1px 2px rgba(0,0,0,.15);
  }
  .hobby-emoji {
    font-size:2.1rem;
    margin-bottom:8px;
  }
  .hobby-name {
    font-size:1.5rem;
    line-height:1.05;
    margin-bottom:4px;
  }
  .hobby-desc {
    font-size:.74rem;
    color:var(--ink-soft);
    line-height:1.35;
    display:-webkit-box;
    -webkit-line-clamp:3;
    -webkit-box-orient:vertical;
    overflow:hidden;
  }
  .hobby-by {
    font-size:.62rem;
    margin-top:8px;
    color:var(--rust);
  }
  .empty-msg {
    grid-column:1/-1;
    text-align:center;
    padding:40px 0;
    color:var(--ink-soft);
    font-size:.85rem;
  }


  
  .card {
    background:var(--card);
    border:1px solid color-mix(in srgb, var(--ink) 10%, transparent);
    border-radius:8px;
    padding:20px;
    box-shadow:2px 2px 0 rgba(0,0,0,.09);
  }
  .label {
    font-family:'JetBrains Mono',monospace;
    font-size:.68rem;
    text-transform:uppercase;
    letter-spacing:.06em;
    color:var(--forest);
    margin-bottom:6px;
  }
  .field {
    width:100%;
    padding:10px 13px;
    border-radius:10px;
    border:1px solid color-mix(in srgb, var(--ink) 18%, transparent);
    background:var(--paper-dark);
    font-size:.88rem;
    color:var(--ink);
  }
  .field:focus, .btn:focus-visible, button:focus-visible {
    outline:2px solid var(--rust);
    outline-offset:2px;
  }
  textarea.field {
    resize:none;
    font-family:'Lora',serif;
  }
  .field::placeholder {
    color:var(--ink-soft);
    opacity:.7;
  }


  
  .detail-card {
    background:var(--card);
    border:1px solid color-mix(in srgb, var(--ink) 10%, transparent);
    border-radius:10px;
    padding:32px;
    box-shadow:3px 4px 0 rgba(0,0,0,.09);
  }
  .back-link {
    background:none;
    border:none;
    font-family:'JetBrains Mono',monospace;
    font-size:.75rem;
    color:var(--ink-soft);
    margin-bottom:22px;
    padding:0;
  }
  .back-link:hover{color:var(--rust);}
  .detail-grid {
    display:grid;
    grid-template-columns:1fr;
    gap:22px;
    margin-bottom:22px;
  }
  @media(min-width:640px){ .detail-grid{grid-template-columns:1fr 1fr;} }
  .gallery-grid {
    display:grid;
    grid-template-columns:repeat(2,1fr);
    gap:10px;
  }
  @media(min-width:640px){ .gallery-grid{grid-template-columns:repeat(3,1fr);} }
  .gallery-grid img {
    width:100%;
    height:110px;
    object-fit:cover;
    border-radius:10px;
    box-shadow:0 4px 10px rgba(0,0,0,.15);
  }

  .project-body {
    font-size:.95rem;
    line-height:1.7;
    color:var(--ink);
  }
  .project-body p{margin:0 0 16px;}
  .project-body h3 {
    color:var(--forest);
    margin:22px 0 10px;
  }
  .project-body figure {
    margin:0 0 20px;
    text-align:center;
  }
  .project-body figure img {
    width:100%;
    max-width:100%;
    border-radius:12px;
    box-shadow:0 6px 14px rgba(0,0,0,.18);
  }
  .project-body figcaption {
    font-size:.72rem;
    color:var(--ink-soft);
    margin-top:8px;
    font-family:'JetBrains Mono',monospace;
  }


  
  .cover {
    position:relative;
    height:190px;
    border-radius:0 0 18px 18px;
    overflow:hidden;
    background:var(--forest);
    background-size:cover;
    background-position:center;
    box-shadow:0 6px 14px rgba(0,0,0,.18);
  }
  @media(min-width:640px){ .cover{height:250px;} }
  .cover-btn {
    position:absolute;
    bottom:12px;
    right:12px;
    font-size:.72rem;
    background:color-mix(in srgb, var(--paper) 90%, transparent);
    border:none;
    padding:7px 14px;
    border-radius:999px;
  }
  .profile-head {
    display:flex;
    align-items:flex-end;
    gap:16px;
    margin-top:-40px;
    padding:0 16px;
  }
  .avatar-wrap{position:relative;}
  .avatar {
    width:96px;
    height:96px;
    border-radius:50%;
    border:4px solid var(--paper);
    box-shadow:0 6px 14px rgba(0,0,0,.18);
    overflow:hidden;
    background:var(--mustard);
    display:flex;
    align-items:center;
    justify-content:center;
    font-size:1.6rem;
  }
  .avatar img {
    width:100%;
    height:100%;
    object-fit:cover;
  }
  .avatar-edit {
    position:absolute;
    bottom:-2px;
    right:-2px;
    font-size:.6rem;
    background:var(--paper);
    padding:2px 7px;
    border-radius:999px;
    box-shadow:0 2px 4px rgba(0,0,0,.2);
    border:none;
  }
  .name-input {
    font-size:1.8rem;
    background:transparent;
    border:none;
    border-bottom:1px dashed color-mix(in srgb, var(--ink) 30%, transparent);
    padding:4px 2px;
  }
  .profile-grid {
    display:grid;
    grid-template-columns:1fr;
    gap:20px;
    margin-top:26px;
  }
  @media(min-width:640px){ .profile-grid{grid-template-columns:1fr 1fr;} }

  .hobby-tags {
    display:flex;
    flex-wrap:wrap;
    gap:8px;
  }
  .hobby-tag {
    font-family:'JetBrains Mono',monospace;
    font-size:.7rem;
    padding:7px 13px;
    border-radius:999px;
    border:1px solid color-mix(in srgb, var(--ink) 20%, transparent);
    background:none;
  }
  .hobby-tag.on {
    background:var(--forest);
    color:#fbf6e8;
    border-color:var(--forest);
  }

  .list-item {
    display:flex;
    align-items:flex-start;
    justify-content:space-between;
    gap:8px;
    font-size:.86rem;
    background:var(--paper-dark);
    border-radius:10px;
    padding:9px 12px;
    margin-bottom:8px;
  }
  .list-item button {
    background:none;
    border:none;
    color:var(--rust);
    font-size:.85rem;
    flex-shrink:0;
  }
  .list-empty {
    color:var(--ink-soft);
    font-size:.78rem;
    font-style:italic;
  }
  .add-item-form {
    display:flex;
    gap:8px;
  }

  .pgallery {
    display:grid;
    grid-template-columns:repeat(3,1fr);
    gap:10px;
    margin-bottom:12px;
  }
  @media(min-width:480px){ .pgallery{grid-template-columns:repeat(4,1fr);} }
  .pgallery-item{position:relative;}
  .pgallery-item img {
    width:100%;
    height:78px;
    object-fit:cover;
    border-radius:8px;
    box-shadow:0 3px 8px rgba(0,0,0,.15);
  }
  .pgallery-remove {
    position:absolute;
    top:-6px;
    right:-6px;
    width:20px;
    height:20px;
    border-radius:50%;
    background:var(--rust);
    color:#fff;
    border:none;
    font-size:.7rem;
    line-height:1;
  }

  .quote-item {
    font-family:'Caveat',cursive;
    font-size:1.15rem;
  }

  .counter-row {
    display:flex;
    align-items:center;
    justify-content:space-between;
  }
  .counter-num {
    font-family:'JetBrains Mono',monospace;
    font-size:1.6rem;
    color:var(--rust);
  }



  
  .fab {
    position:fixed;
    bottom:24px;
    right:24px;
    z-index:35;
    box-shadow:2px 3px 0 rgba(0,0,0,.22);
  }


  
  .overlay {
    position:fixed;
    inset:0;
    background:rgba(0,0,0,.5);
    z-index:50;
    display:flex;
    align-items:center;
    justify-content:center;
    padding:16px;
  }
  .modal {
    background:var(--card);
    border:1px solid color-mix(in srgb, var(--ink) 12%, transparent);
    border-radius:10px;
    padding:26px;
    max-width:480px;
    width:100%;
    max-height:85vh;
    overflow-y:auto;
    box-shadow:4px 5px 0 rgba(0,0,0,.18);
  }
  .modal-sm{max-width:380px;}
  .modal-head {
    display:flex;
    align-items:center;
    justify-content:space-between;
    margin-bottom:12px;
  }
  .modal-title {
    font-size:1.7rem;
    color:var(--forest);
    margin:0;
  }
  .modal-close {
    background:none;
    border:none;
    font-size:1.4rem;
    line-height:1;
    color:var(--ink-soft);
    padding:0;
  }
  .modal-close:hover{color:var(--rust);}
  .modal-hint {
    font-size:.78rem;
    color:var(--ink-soft);
    line-height:1.5;
    margin:0 0 16px;
  }
  .signin-error {
    font-family:'JetBrains Mono',monospace;
    font-size:.78rem;
    line-height:1.5;
    color:#fff;
    background:var(--rust);
    border-radius:8px;
    padding:10px 12px;
    margin:0 0 14px;
    font-weight:600;
  }
  .modal-form {
    display:flex;
    flex-direction:column;
    gap:11px;
  }
  .publish-note {
    font-family:'JetBrains Mono',monospace;
    font-size:.66rem;
    color:var(--ink-soft);
  }
  .publish-note b {
    color:var(--rust);
    font-style:normal;
  }
  .file-label {
    font-family:'JetBrains Mono',monospace;
    font-size:.68rem;
    text-transform:uppercase;
    letter-spacing:.06em;
    color:var(--forest);
    display:block;
    margin-bottom:5px;
  }

  .toast {
    position:fixed;
    bottom:24px;
    left:50%;
    transform:translateX(-50%);
    z-index:60;
    background:var(--forest);
    color:#fbf6e8;
    padding:11px 22px;
    border-radius:999px;
    font-family:'JetBrains Mono',monospace;
    font-size:.8rem;
    box-shadow:0 8px 18px rgba(0,0,0,.3);
    animation:toastIn .25s ease both;
  }
  @keyframes toastIn{from{opacity:0; transform:translate(-50%,10px);} to{opacity:1; transform:translate(-50%,0);}}

  .fade-in{animation:fadeIn .45s ease both;}
  @keyframes fadeIn{from{opacity:0; transform:translateY(8px);} to{opacity:1; transform:translateY(0);}}
  @media(prefers-reduced-motion:reduce){ .fade-in,.toast{animation:none !important;} *{transition:none !important;} }

  ::-webkit-scrollbar{width:10px;} ::-webkit-scrollbar-thumb{background:var(--cork); border-radius:6px;}

  .thought {
    max-width:520px;
    margin:26px auto 0;
    font-size:1.25rem;
    color:var(--ink-soft);
    background:none;
    border:none;
    padding:0;
    text-align:center;
    line-height:1.4;
  }
  .thought:hover{color:var(--rust);}

  .time-rows {
    display:grid;
    gap:9px;
    margin-bottom:14px;
  }
  .time-row {
    display:grid;
    grid-template-columns:96px 62px 1fr;
    align-items:center;
    gap:10px;
    font-size:.82rem;
  }
  .time-row input {
    width:100%;
    padding:6px 8px;
    border-radius:6px;
    border:1px solid color-mix(in srgb, var(--ink) 18%, transparent);
    background:var(--paper-dark);
    font-family:'JetBrains Mono',monospace;
    font-size:.75rem;
    color:var(--ink);
  }
  .bar {
    height:9px;
    border-radius:999px;
    background:var(--paper-dark);
    overflow:hidden;
  }
  .bar span {
    display:block;
    height:100%;
    background:var(--forest);
  }
  .bar span.hi{background:var(--rust);}

  .stack {
    display:grid;
    gap:12px;
  }
  .soft-note {
    font-size:.78rem;
    color:var(--ink-soft);
    line-height:1.5;
    margin:0;
  }
  .ask {
    font-family:'Caveat',cursive;
    font-size:1.15rem;
    margin:0 0 4px;
  }

  .log-strip {
    display:flex;
    flex-wrap:wrap;
    align-items:center;
    gap:10px;
    margin-top:26px;
    padding-top:18px;
    border-top:1px dashed color-mix(in srgb, var(--ink) 22%, transparent);
  }
  .streak {
    font-family:'JetBrains Mono',monospace;
    font-size:.72rem;
    color:var(--rust);
  }
  .status-select {
    font-family:'JetBrains Mono',monospace;
    font-size:.72rem;
    padding:7px 10px;
    border-radius:999px;
    border:1px solid color-mix(in srgb, var(--ink) 22%, transparent);
    background:var(--paper-dark);
    color:var(--ink);
  }
  .timer-num {
    font-family:'JetBrains Mono',monospace;
    font-size:1.4rem;
    color:var(--forest);
  }

  .timeline {
    border-left:2px solid color-mix(in srgb, var(--ink) 18%, transparent);
    margin:12px 0 12px 6px;
    padding-left:16px;
  }
  .timeline-item {
    position:relative;
    margin-bottom:12px;
    font-size:.86rem;
  }
  .timeline-item:before {
    content:'';
    position:absolute;
    left:-22px;
    top:6px;
    width:9px;
    height:9px;
    border-radius:50%;
    background:var(--mustard);
  }
  .timeline-date {
    font-family:'JetBrains Mono',monospace;
    font-size:.66rem;
    color:var(--ink-soft);
    display:block;
  }
  .timeline-item button {
    background:none;
    border:none;
    color:var(--rust);
    font-size:.8rem;
    float:right;
  }
  .mini-form {
    display:flex;
    flex-wrap:wrap;
    gap:8px;
  }
  .mini-form .field{flex:1 1 140px;}

  .entry {
    border-bottom:1px dashed color-mix(in srgb, var(--ink) 15%, transparent);
    padding:8px 0;
    font-size:.86rem;
  }
  .entry:last-child{border-bottom:none;}
  .entry-date {
    font-family:'JetBrains Mono',monospace;
    font-size:.64rem;
    color:var(--ink-soft);
    display:block;
    margin-bottom:2px;
  }

  
  #scene3d{
    position:fixed; inset:0; width:100%; height:100%;
    z-index:0; pointer-events:none; opacity:.5;
  }
  .app-shell{position:relative; z-index:1;}

  .hobby-grid, .profile-grid, .detail-grid, .hero-inner{ perspective:1100px; }

  .tilt3d{
    transform-style:preserve-3d;
    transition:transform .5s cubic-bezier(.22,.8,.3,1), box-shadow .5s ease;
    will-change:transform;
  }
  .tilt3d.is-tilting{ transition:transform .08s linear, box-shadow .3s ease; }
  .tilt3d .hobby-emoji, .tilt3d .hobby-name, .tilt3d .washi, .tilt3d .pin{
    transform:translateZ(28px);
  }
  .tilt3d .hobby-desc{ transform:translateZ(14px); }

  .hobby-card:hover{
    box-shadow:0 26px 45px -22px color-mix(in srgb, var(--ink) 55%, transparent);
  }

  .hero-title{
    transform-style:preserve-3d;
    text-shadow:
      1px 1px 0 color-mix(in srgb, var(--ink) 22%, transparent),
      2px 2px 0 color-mix(in srgb, var(--ink) 16%, transparent),
      4px 5px 12px color-mix(in srgb, var(--ink) 28%, transparent);
    animation:float3d 7s ease-in-out infinite;
  }
  @keyframes float3d{
    0%,100%{ transform:translate3d(0,0,0) rotateX(0deg); }
    50%{ transform:translate3d(0,-6px,30px) rotateX(4deg); }
  }

  .reveal3d{
    opacity:0;
    transform:perspective(900px) translate3d(0,26px,-70px) rotateX(10deg);
    transition:opacity .7s ease, transform .7s cubic-bezier(.22,.8,.3,1);
  }
  .reveal3d.shown{
    opacity:1;
    transform:perspective(900px) translate3d(0,0,0) rotateX(0deg);
  }

  .