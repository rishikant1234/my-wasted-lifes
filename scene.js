/* ---------------------------------------------------------------
   3D scene + motion layer. vanilla, no libs, works offline.
   --------------------------------------------------------------- */
(function(){
  const reduce = window.matchMedia && matchMedia('(prefers-reduced-motion: reduce)').matches;
  const cv = document.getElementById('scene3d');
  if(cv && !reduce){
    const ctx = cv.getContext('2d');
    let W=0,H=0,dpr=1;
    function resize(){
      dpr = Math.min(window.devicePixelRatio||1, 2);
      W = cv.clientWidth; H = cv.clientHeight;
      cv.width = W*dpr; cv.height = H*dpr;
      ctx.setTransform(dpr,0,0,dpr,0,0);
    }
    resize();
    window.addEventListener('resize', resize);

    // a handful of wireframe cubes drifting in real perspective space
    const CUBE = [[-1,-1,-1],[1,-1,-1],[1,1,-1],[-1,1,-1],[-1,-1,1],[1,-1,1],[1,1,1],[-1,1,1]];
    const EDGES = [[0,1],[1,2],[2,3],[3,0],[4,5],[5,6],[6,7],[7,4],[0,4],[1,5],[2,6],[3,7]];
    const shapes = [];
    for(let i=0;i<14;i++){
      shapes.push({
        x:(Math.random()-.5)*900, y:(Math.random()-.5)*700, z:300+Math.random()*900,
        s:40+Math.random()*90,
        rx:Math.random()*6, ry:Math.random()*6,
        vrx:(Math.random()-.5)*0.004, vry:(Math.random()-.5)*0.005,
        vz:-(0.12+Math.random()*0.35), vy:(Math.random()-.5)*0.08
      });
    }
    const dots = [];
    for(let i=0;i<110;i++){
      dots.push({x:(Math.random()-.5)*1600, y:(Math.random()-.5)*1200, z:100+Math.random()*1300, v:0.25+Math.random()*0.8});
    }

    let mx=0,my=0,tx=0,ty=0;
    window.addEventListener('pointermove', e=>{
      tx = (e.clientX/window.innerWidth - .5)*2;
      ty = (e.clientY/window.innerHeight - .5)*2;
    }, {passive:true});

    function inkColor(alpha){
      const dark = document.documentElement.classList.contains('dark') || document.body.classList.contains('dark');
      return dark ? 'rgba(199,181,147,'+alpha+')' : 'rgba(54,38,25,'+alpha+')';
    }
    function accent(alpha){
      const dark = document.documentElement.classList.contains('dark') || document.body.classList.contains('dark');
      return dark ? 'rgba(226,136,78,'+alpha+')' : 'rgba(189,91,42,'+alpha+')';
    }

    function project(p){
      const f = 620;
      const z = p.z;
      if(z <= 1) return null;
      const k = f/z;
      return { x: W/2 + (p.x - mx*140)*k, y: H/2 + (p.y - my*100)*k, k };
    }

    function frame(){
      mx += (tx-mx)*0.05; my += (ty-my)*0.05;
      ctx.clearRect(0,0,W,H);

      // depth dust
      for(const d of dots){
        d.z -= d.v;
        if(d.z < 60){ d.z = 1400; d.x=(Math.random()-.5)*1600; d.y=(Math.random()-.5)*1200; }
        const p = project(d);
        if(!p) continue;
        const r = Math.max(.4, p.k*1.7);
        ctx.fillStyle = inkColor(Math.min(.4, p.k*0.55));
        ctx.beginPath(); ctx.arc(p.x,p.y,r,0,Math.PI*2); ctx.fill();
      }

      // wireframe cubes
      for(const s of shapes){
        s.rx += s.vrx; s.ry += s.vry; s.z += s.vz; s.y += s.vy;
        if(s.z < 140){ s.z = 1200; s.x=(Math.random()-.5)*900; s.y=(Math.random()-.5)*700; }
        const cx=Math.cos(s.rx), sx=Math.sin(s.rx), cy=Math.cos(s.ry), sy=Math.sin(s.ry);
        const pts = CUBE.map(v=>{
          let [x,y,z] = v;
          let y1 = y*cx - z*sx, z1 = y*sx + z*cx;
          let x1 = x*cy + z1*sy, z2 = -x*sy + z1*cy;
          return project({x:s.x + x1*s.s, y:s.y + y1*s.s, z:s.z + z2*s.s});
        });
        const alpha = Math.max(0, Math.min(.5, (1200 - s.z)/1200 * .5));
        ctx.strokeStyle = (s.s > 100 ? accent(alpha*0.9) : inkColor(alpha));
        ctx.lineWidth = 1;
        ctx.beginPath();
        for(const [a,b] of EDGES){
          if(!pts[a] || !pts[b]) continue;
          ctx.moveTo(pts[a].x, pts[a].y);
          ctx.lineTo(pts[b].x, pts[b].y);
        }
        ctx.stroke();
      }
      requestAnimationFrame(frame);
    }
    requestAnimationFrame(frame);
  }

  if(reduce) return;

  const TILT_SEL = '.hobby-card, .card, .detail-card, .cover, .list-item, .counter-row, .timeline-item';
  const REVEAL_SEL = '.hobby-card, .card, .detail-card, .timeline-item, .project-body img, .gallery-grid img, .section-title';

  const io = new IntersectionObserver(entries=>{
    for(const en of entries){
      if(en.isIntersecting){ en.target.classList.add('shown'); io.unobserve(en.target); }
    }
  }, {threshold:.08});

  function enhance(root){
    (root.querySelectorAll ? root.querySelectorAll(TILT_SEL) : []).forEach(el=>{
      if(el.dataset.tilt3d) return;
      el.dataset.tilt3d = '1';
      el.classList.add('tilt3d');
    });
    (root.querySelectorAll ? root.querySelectorAll(REVEAL_SEL) : []).forEach((el,i)=>{
      if(el.dataset.reveal3d) return;
      el.dataset.reveal3d = '1';
      el.classList.add('reveal3d');
      el.style.transitionDelay = Math.min(i*35, 350) + 'ms';
      io.observe(el);
    });
  }

  const app = document.getElementById('app');
  if(app){
    enhance(app);
    new MutationObserver(()=> enhance(app)).observe(app, {childList:true, subtree:true});
  }

  // real per-card tilt driven by pointer position
  document.addEventListener('pointermove', e=>{
    const card = e.target && e.target.closest ? e.target.closest('.tilt3d') : null;
    if(!card) return;
    const r = card.getBoundingClientRect();
    const px = (e.clientX - r.left)/r.width - .5;
    const py = (e.clientY - r.top)/r.height - .5;
    card.classList.add('is-tilting');
    card.style.transform =
      'perspective(900px) rotateY(' + (px*11).toFixed(2) + 'deg) rotateX(' +
      (-py*11).toFixed(2) + 'deg) translateZ(22px) scale(1.02)';
  }, {passive:true});

  document.addEventListener('pointerout', e=>{
    const card = e.target && e.target.closest ? e.target.closest('.tilt3d') : null;
    if(!card || (e.relatedTarget && card.contains(e.relatedTarget))) return;
    card.classList.remove('is-tilting');
    card.style.transform = '';
  }, {passive:true});
})();
